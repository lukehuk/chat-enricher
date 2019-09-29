using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_enricher
{
    public partial class ChatInputControl : UserControl
    {
        private IMessageHandler messageHandler;

        public IMessageHandler MessageHandler
        {
            get { return messageHandler; }
            set
            {
                messageHandler = value;
                this.sendButton.Enabled = true;
            }
        }

        public IButtonControl SendButton
        {
            get
            {
                return sendButton;
            }
        }

        public ChatInputControl()
        {
            InitializeComponent();
            //Disable the send button until a message handler is set
            this.sendButton.Enabled = false;
        }

        //When the send button is pressed, publish the user entered text and then clear the input text field
        private void SendButton_Click(object sender, EventArgs e)
        {
            MessageHandler.PublishMessage(this.chatInputTextBox.Text);
            this.chatInputTextBox.Text = "";
        }
    }
}
