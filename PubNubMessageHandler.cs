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
        private const string ModelId = "ex_isnnZRbS"; //MonkeyLearn "Entity Extractor" model

        private string userId = Guid.NewGuid().ToString();
        private Pubnub pubnub;
        private ChatOutputControl chatOutputControl;

        public PubNubMessageHandler(ChatOutputControl chatOutputControl)
        {
            this.chatOutputControl = chatOutputControl;

            //Configure PubNub
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
                    
                    //Determine if the message publisher is the current user
                    bool messageFromCurrentUser = message.Publisher.ToString() == userId;

                    //Deserialize the JSON message
                    EnrichedChatMessage chatMessage = JsonConvert.DeserializeObject<EnrichedChatMessage>(message.Message.ToString());

                    //Verify that both the message text and extraction properties were defined in the message
                    if (chatMessage.Text == null || chatMessage.Extractions == null)
                    {
                        Console.WriteLine("Message arrived with an unexpected format:", message.Message);
                    }
                    else
                    {
                        //Update the output user control with the new message text
                        chatOutputControl.NewMessage(chatMessage.Text, messageFromCurrentUser);

                        //Convert the message enrichment data into formatted JSON to be displayed 
                        string formattedJsonMetadata = JsonConvert.SerializeObject(chatMessage.Extractions, Formatting.Indented);
                        chatOutputControl.UpdateMetadata(formattedJsonMetadata == "[]" ? "No additional metadata" : formattedJsonMetadata);
                    }
                },
                (pubnubObj, presence) => { },
                (pubnubObj, status) => { }
            );
            pubnub.AddListener(generalSubscribeCallack);

            //Subscribe to the chat channel
            pubnub.Subscribe<string>()
                .Channels(new string[]{
                    ChannelName
                })
                .Execute();
        }

        //Called when a chat message should be sent. Accepts a message string, constructs
        //a chat message object and publishes the chat message using PubNub 
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

        //Constructs and returns a dictionary of properties representing a chat message.
        //The object contains the chat message text and enrichment parameters
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
