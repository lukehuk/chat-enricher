namespace chat_enricher
{
    partial class ChatOutputControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chatMessagesGridView = new System.Windows.Forms.DataGridView();
            this.chatMetadataTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chatMessagesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // chatMessagesGridView
            // 
            this.chatMessagesGridView.AllowUserToAddRows = false;
            this.chatMessagesGridView.AllowUserToDeleteRows = false;
            this.chatMessagesGridView.AllowUserToResizeColumns = false;
            this.chatMessagesGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.chatMessagesGridView.BackgroundColor = System.Drawing.Color.White;
            this.chatMessagesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chatMessagesGridView.ColumnHeadersVisible = false;
            this.chatMessagesGridView.GridColor = System.Drawing.Color.White;
            this.chatMessagesGridView.Location = new System.Drawing.Point(15, 15);
            this.chatMessagesGridView.Name = "chatMessagesGridView";
            this.chatMessagesGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chatMessagesGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.chatMessagesGridView.RowTemplate.DividerHeight = 5;
            this.chatMessagesGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatMessagesGridView.Size = new System.Drawing.Size(350, 325);
            this.chatMessagesGridView.TabIndex = 0;
            this.chatMessagesGridView.SelectionChanged += new System.EventHandler(this.ChatMessagesGridView_SelectionChanged);
            // 
            // chatMetadataTextBox
            // 
            this.chatMetadataTextBox.Location = new System.Drawing.Point(380, 15);
            this.chatMetadataTextBox.Multiline = true;
            this.chatMetadataTextBox.Name = "chatMetadataTextBox";
            this.chatMetadataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatMetadataTextBox.Size = new System.Drawing.Size(350, 325);
            this.chatMetadataTextBox.TabIndex = 1;
            // 
            // ChatOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chatMetadataTextBox);
            this.Controls.Add(this.chatMessagesGridView);
            this.Name = "ChatOutputControl";
            this.Size = new System.Drawing.Size(745, 355);
            ((System.ComponentModel.ISupportInitialize)(this.chatMessagesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView chatMessagesGridView;
        private System.Windows.Forms.TextBox chatMetadataTextBox;
    }
}
