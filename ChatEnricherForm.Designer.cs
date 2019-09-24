namespace chat_enricher
{
    partial class ChatEnricherForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatInputControl1 = new chat_enricher.ChatInputControl();
            this.chatOutputControl1 = new chat_enricher.ChatOutputControl();
            this.SuspendLayout();
            // 
            // chatInputControl1
            // 
            this.chatInputControl1.Location = new System.Drawing.Point(25, 355);
            this.chatInputControl1.Name = "chatInputControl1";
            this.chatInputControl1.Size = new System.Drawing.Size(695, 54);
            this.chatInputControl1.TabIndex = 1;
            this.chatInputControl1.Load += new System.EventHandler(this.ChatInputControl1_Load);
            // 
            // chatOutputControl1
            // 
            this.chatOutputControl1.Location = new System.Drawing.Point(0, 0);
            this.chatOutputControl1.Name = "chatOutputControl1";
            this.chatOutputControl1.Size = new System.Drawing.Size(745, 355);
            this.chatOutputControl1.TabIndex = 0;
            this.chatOutputControl1.Load += new System.EventHandler(this.ChatOutputControl1_Load);
            // 
            // ChatEnricherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 426);
            this.Controls.Add(this.chatInputControl1);
            this.Controls.Add(this.chatOutputControl1);
            this.Name = "ChatEnricherForm";
            this.Text = "Chat Enricher";
            this.Load += new System.EventHandler(this.ChatEnricherForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ChatOutputControl chatOutputControl1;
        private ChatInputControl chatInputControl1;
    }
}

