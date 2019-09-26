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
                return this.sendButton;
            }
        }

        public ChatInputControl()
        {
            InitializeComponent();
            this.sendButton.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageHandler.PublishMessage(this.chatInputTextBox.Text);
            this.chatInputTextBox.Text = "";
        }
    }
}
