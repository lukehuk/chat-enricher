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

            //Create the chat message columns and adjust the styling
            this.chatMessagesGridView.Columns.Add("received", "Received");
            this.chatMessagesGridView.Columns.Add("sent", "Sent");
            this.chatMessagesGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.chatMessagesGridView.Columns[0].DividerWidth = 5;
            this.chatMessagesGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Called when a new message is received. 
        //Adds the message to the relevant chat message data grid view 
        public void NewMessage(string message, bool currentUser)
        {
            if (currentUser) {
                Invoke(new Action(() => {
                    int rowIndex = this.chatMessagesGridView.Rows.Add(null, message);
                    DataGridViewCellStyle sentStyle = new DataGridViewCellStyle();
                    sentStyle.BackColor = Color.CornflowerBlue;
                    this.chatMessagesGridView.Rows[rowIndex].Cells[1].Style = sentStyle;
                }));
            }
            else
            {
                Invoke(new Action(() => {
                    int rowIndex = this.chatMessagesGridView.Rows.Add(message, null);
                    DataGridViewCellStyle receivedStyle = new DataGridViewCellStyle();
                    receivedStyle.BackColor = Color.Gray;
                    this.chatMessagesGridView.Rows[rowIndex].Cells[0].Style = receivedStyle;
                }));
            }
        }

        //Allows the chat metadata textbox to be repopulated with different text
        public void UpdateMetadata(string metadata)
        {
            Invoke(new Action(() => { this.chatMetadataTextBox.Text = metadata; }));
        }

        //Prevents cell selection without disabling the data grid view
        private void ChatMessagesGridView_SelectionChanged(object sender, EventArgs e)
        {
            chatMessagesGridView.ClearSelection();
        }
    }
}
