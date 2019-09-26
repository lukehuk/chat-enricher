using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PubnubApi;

namespace chat_enricher
{
    class PubNubMessageHandler : IMessageHandler
    {
        private const string PublishKey = "pub-c-73a336cd-cca2-438f-a7b2-cf766b07847a";
        private const string SubscribeKey = "sub-c-a4f0a560-d32d-11e9-a219-a2442d3e7ccc";
        private const string ChannelName = "chat-enrichment";
        private const string ModelType = "extractor";
        private const string ModelId = "ex_vqBQ7V9B";

        private string userId = Guid.NewGuid().ToString();
        private Pubnub pubnub;
        private ChatOutputControl chatOutputControl;

        public PubNubMessageHandler(ChatOutputControl chatOutputControl)
        {
            this.chatOutputControl = chatOutputControl;

            PNConfiguration pnConfiguration = new PNConfiguration
            {
                PublishKey = PublishKey,
                SubscribeKey = SubscribeKey,
                Uuid = userId,
                Secure = false
            };

            this.pubnub = new Pubnub(pnConfiguration);

            //Add listener to receive Publish messages and Presence events
            SubscribeCallbackExt generalSubscribeCallack = new SubscribeCallbackExt(
                (Pubnub pubnubObj, PNMessageResult<object> message) => {
                    Console.WriteLine(message.Message);
                    bool messageFromCurrentUser = message.Publisher.ToString() == userId;

                    var chatMessage = JsonConvert.DeserializeObject<IChatMessage>(message.Message.ToString());
                    if (chatMessage.Text == null || chatMessage.Extractions == null)
                    {
                        Console.WriteLine("Message arrived with an unexpected format:", message.Message);
                    }
                    else
                    {
                        chatOutputControl.NewMessage(chatMessage.Text, messageFromCurrentUser);

                        string formattedJsonMetadata = JsonConvert.SerializeObject(chatMessage.Extractions, Formatting.Indented);
                        chatOutputControl.UpdateMetadata(formattedJsonMetadata == "[]" ? "No additional metadata" : formattedJsonMetadata);
                    }
                },
                (pubnubObj, presence) => { },
                (pubnubObj, status) => { }
            );
            pubnub.AddListener(generalSubscribeCallack);

            pubnub.Subscribe<string>()
                .Channels(new string[]{
                    ChannelName
                })
                .Execute();
        }

        public void PublishMessage(string messageText)
        {
            pubnub.Publish()
            .Channel(ChannelName)
            .Message(GenerateChatMessage(messageText))
            .Execute(new PNPublishResultExt(
                (result, status) => {
                    if (status.Error)
                    {
                        Console.WriteLine(status.ErrorData.Information);
                    }
                }
            ));
        }

        private object GenerateChatMessage(string messageText)
        {
            Dictionary<string, string> chatMessage = new Dictionary<string, string>
            {
                { "model_type", ModelType },
                { "model_id", ModelId },
                { "input_text", messageText }
            };
            return chatMessage;
        }
    }
}
