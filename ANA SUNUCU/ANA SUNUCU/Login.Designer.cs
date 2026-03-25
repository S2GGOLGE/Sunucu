namespace ANA_SUNUCU
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            label2 = new Label();
            usernametxt = new TextBox();
            passtxt = new TextBox();
            button1 = new Button();
            exit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(298, 133);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(298, 195);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // usernametxt
            // 
            usernametxt.Location = new Point(369, 124);
            usernametxt.Name = "usernametxt";
            usernametxt.Size = new Size(100, 23);
            usernametxt.TabIndex = 2;
            // 
            // passtxt
            // 
            passtxt.Location = new Point(369, 195);
            passtxt.Name = "passtxt";
            passtxt.Size = new Size(100, 23);
            passtxt.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(382, 227);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // exit
            // 
            exit.Location = new Point(382, 256);
            exit.Name = "exit";
            exit.Size = new Size(75, 23);
            exit.TabIndex = 5;
            exit.Text = "Çıkış";
            exit.UseVisualStyleBackColor = true;
            exit.Click += exit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exit);
            Controls.Add(button1);
            Controls.Add(passtxt);
            Controls.Add(usernametxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox usernametxt;
        private TextBox passtxt;
        private Button button1;
        private Button exit;
    }
}