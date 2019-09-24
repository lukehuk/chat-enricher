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
            this.chatMessagesGridView = new System.Windows.Forms.DataGridView();
            this.chatMetadataTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chatMessagesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // chatMessagesGridView
            // 
            this.chatMessagesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chatMessagesGridView.Location = new System.Drawing.Point(15, 15);
            this.chatMessagesGridView.Name = "chatMessagesGridView";
            this.chatMessagesGridView.Size = new System.Drawing.Size(350, 325);
            this.chatMessagesGridView.TabIndex = 0;
            // 
            // chatMetadataTextBox
            // 
            this.chatMetadataTextBox.Location = new System.Drawing.Point(380, 15);
            this.chatMetadataTextBox.Multiline = true;
            this.chatMetadataTextBox.Name = "chatMetadataTextBox";
            this.chatMetadataTextBox.Size = new System.Drawing.Size(350, 325);
            this.chatMetadataTextBox.TabIndex = 1;
            this.chatMetadataTextBox.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
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
