using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_enricher
{
    public partial class ChatEnricherForm : Form
    {
        public ChatEnricherForm()
        {
            InitializeComponent();
            //Create a PubNub message handler, passing it the output user control to display received messages
            IMessageHandler pubnubMessageHandler = new PubNubMessageHandler(this.chatOutputControl1);

            //Pass the message handler to the input user control so messages can be published
            this.chatInputControl1.MessageHandler = pubnubMessageHandler;

            //This statement allows the 'ENTER' key to be used to submit a message
            this.AcceptButton = this.chatInputControl1.SendButton;
        }
    }
}
