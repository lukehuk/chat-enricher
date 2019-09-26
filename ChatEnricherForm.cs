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
            PubNubMessageHandler pubnubMessageHandler = new PubNubMessageHandler(this.chatOutputControl1);
            this.chatInputControl1.MessageHandler = pubnubMessageHandler;
            this.AcceptButton = this.chatInputControl1.SendButton;
        }
    }
}
