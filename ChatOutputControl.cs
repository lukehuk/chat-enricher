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
    public partial class ChatOutputControl : UserControl
    {
        public ChatOutputControl()
        {
            InitializeComponent();
            this.chatMessagesGridView.Columns.Add("received", "Received");
            this.chatMessagesGridView.Columns.Add("sent", "Sent");
        }

        public void NewMessage(string message, bool currentUser)
        {
            if (currentUser) {
                Invoke(new Action(() => { this.chatMessagesGridView.Rows.Add(null, message); }));
            }
            else
            {
                Invoke(new Action(() => { this.chatMessagesGridView.Rows.Add(message, null); }));
            }
        }

        internal void UpdateMetadata(string metadata)
        {
            Invoke(new Action(() => { this.chatMetadataTextBox.Text = metadata; }));
        }
    }
}
