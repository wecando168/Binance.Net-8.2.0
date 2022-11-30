namespace BinanceNetCoreDemo
{
    partial class SettingsWindow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_api_key = new System.Windows.Forms.Label();
            this.label_api_secret = new System.Windows.Forms.Label();
            this.textBox_api_key = new System.Windows.Forms.TextBox();
            this.textBox_api_secret = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_SettingsWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_api_key
            // 
            this.label_api_key.AutoSize = true;
            this.label_api_key.Location = new System.Drawing.Point(10, 37);
            this.label_api_key.Name = "label_api_key";
            this.label_api_key.Size = new System.Drawing.Size(51, 17);
            this.label_api_key.TabIndex = 0;
            this.label_api_key.Text = "Api key";
            // 
            // label_api_secret
            // 
            this.label_api_secret.AutoSize = true;
            this.label_api_secret.Location = new System.Drawing.Point(10, 75);
            this.label_api_secret.Name = "label_api_secret";
            this.label_api_secret.Size = new System.Drawing.Size(66, 17);
            this.label_api_secret.TabIndex = 1;
            this.label_api_secret.Text = "Api secret";
            // 
            // textBox_api_key
            // 
            this.textBox_api_key.Location = new System.Drawing.Point(86, 34);
            this.textBox_api_key.Name = "textBox_api_key";
            this.textBox_api_key.Size = new System.Drawing.Size(256, 23);
            this.textBox_api_key.TabIndex = 2;
            // 
            // textBox_api_secret
            // 
            this.textBox_api_secret.Location = new System.Drawing.Point(86, 72);
            this.textBox_api_secret.Name = "textBox_api_secret";
            this.textBox_api_secret.Size = new System.Drawing.Size(256, 23);
            this.textBox_api_secret.TabIndex = 3;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(267, 112);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 4;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // menu_strip
            // 
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SettingsWindow});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(356, 25);
            this.menu_strip.TabIndex = 6;
            this.menu_strip.Text = "menuStrip1";
            // 
            // toolStripMenuItem_SettingsWindow
            // 
            this.toolStripMenuItem_SettingsWindow.Name = "toolStripMenuItem_SettingsWindow";
            this.toolStripMenuItem_SettingsWindow.Size = new System.Drawing.Size(113, 21);
            this.toolStripMenuItem_SettingsWindow.Text = "SettingsWindow";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_api_secret);
            this.Controls.Add(this.textBox_api_key);
            this.Controls.Add(this.label_api_secret);
            this.Controls.Add(this.label_api_key);
            this.Controls.Add(this.menu_strip);
            this.Name = "SettingsWindow";
            this.Size = new System.Drawing.Size(356, 150);
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_api_key;
        private Label label_api_secret;
        private TextBox textBox_api_key;
        private TextBox textBox_api_secret;
        private Button button_ok;
        private Label label1;
        private MenuStrip menu_strip;
        private ToolStripMenuItem toolStripMenuItem_SettingsWindow;
    }
}
