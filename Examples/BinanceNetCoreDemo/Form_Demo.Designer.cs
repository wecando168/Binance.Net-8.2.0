namespace BinanceNetCoreDemo
{
    partial class Form_Demo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_Symbol = new System.Windows.Forms.DataGridView();
            this.splitContainer_Demo = new System.Windows.Forms.SplitContainer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.dataGridView_exchangeHistory = new System.Windows.Forms.DataGridView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_api_key = new System.Windows.Forms.Label();
            this.groupBox_buy_sell = new System.Windows.Forms.GroupBox();
            this.textBox_amount = new System.Windows.Forms.TextBox();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.button_buy = new System.Windows.Forms.Button();
            this.button_sell = new System.Windows.Forms.Button();
            this.label_amount = new System.Windows.Forms.Label();
            this.label_buySellPrice = new System.Windows.Forms.Label();
            this.label_exchange_history = new System.Windows.Forms.Label();
            this.label_price = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_change_in_24_hour = new System.Windows.Forms.Label();
            this.label_highest_price = new System.Windows.Forms.Label();
            this.label_volume = new System.Windows.Forms.Label();
            this.label_lowest_price = new System.Windows.Forms.Label();
            this.label_Symbol = new System.Windows.Forms.Label();
            this.label_api_secret = new System.Windows.Forms.Label();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.textBox_api_key = new System.Windows.Forms.TextBox();
            this.buttonSetApiCredentials = new System.Windows.Forms.Button();
            this.textBox_api_secret = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Symbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Demo)).BeginInit();
            this.splitContainer_Demo.Panel1.SuspendLayout();
            this.splitContainer_Demo.Panel2.SuspendLayout();
            this.splitContainer_Demo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_exchangeHistory)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox_buy_sell.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Symbol
            // 
            this.dataGridView_Symbol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Symbol.Location = new System.Drawing.Point(0, 40);
            this.dataGridView_Symbol.Name = "dataGridView_Symbol";
            this.dataGridView_Symbol.RowHeadersVisible = false;
            this.dataGridView_Symbol.RowTemplate.Height = 25;
            this.dataGridView_Symbol.Size = new System.Drawing.Size(200, 468);
            this.dataGridView_Symbol.TabIndex = 0;
            this.dataGridView_Symbol.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Symbol_CellClick);
            // 
            // splitContainer_Demo
            // 
            this.splitContainer_Demo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Demo.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Demo.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Demo.Name = "splitContainer_Demo";
            // 
            // splitContainer_Demo.Panel1
            // 
            this.splitContainer_Demo.Panel1.Controls.Add(this.dataGridView_Symbol);
            this.splitContainer_Demo.Panel1.Controls.Add(this.splitter1);
            this.splitContainer_Demo.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer_Demo.Panel2
            // 
            this.splitContainer_Demo.Panel2.Controls.Add(this.dataGridView_exchangeHistory);
            this.splitContainer_Demo.Panel2.Controls.Add(this.splitter2);
            this.splitContainer_Demo.Panel2.Controls.Add(this.panel2);
            this.splitContainer_Demo.Size = new System.Drawing.Size(800, 508);
            this.splitContainer_Demo.SplitterDistance = 200;
            this.splitContainer_Demo.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 37);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(200, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_search);
            this.panel1.Controls.Add(this.button_search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 37);
            this.panel1.TabIndex = 3;
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(12, 7);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(100, 23);
            this.textBox_search.TabIndex = 1;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(118, 7);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 2;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // dataGridView_exchangeHistory
            // 
            this.dataGridView_exchangeHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_exchangeHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_exchangeHistory.Location = new System.Drawing.Point(0, 356);
            this.dataGridView_exchangeHistory.Name = "dataGridView_exchangeHistory";
            this.dataGridView_exchangeHistory.RowTemplate.Height = 25;
            this.dataGridView_exchangeHistory.Size = new System.Drawing.Size(596, 152);
            this.dataGridView_exchangeHistory.TabIndex = 17;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 353);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(596, 3);
            this.splitter2.TabIndex = 19;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_api_key);
            this.panel2.Controls.Add(this.groupBox_buy_sell);
            this.panel2.Controls.Add(this.label_exchange_history);
            this.panel2.Controls.Add(this.label_price);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label_Symbol);
            this.panel2.Controls.Add(this.label_api_secret);
            this.panel2.Controls.Add(this.richTextBox_log);
            this.panel2.Controls.Add(this.textBox_api_key);
            this.panel2.Controls.Add(this.buttonSetApiCredentials);
            this.panel2.Controls.Add(this.textBox_api_secret);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 353);
            this.panel2.TabIndex = 18;
            // 
            // label_api_key
            // 
            this.label_api_key.AutoSize = true;
            this.label_api_key.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_api_key.Location = new System.Drawing.Point(12, 19);
            this.label_api_key.Name = "label_api_key";
            this.label_api_key.Size = new System.Drawing.Size(66, 21);
            this.label_api_key.TabIndex = 9;
            this.label_api_key.Text = "Api key";
            // 
            // groupBox_buy_sell
            // 
            this.groupBox_buy_sell.Controls.Add(this.textBox_amount);
            this.groupBox_buy_sell.Controls.Add(this.textBox_price);
            this.groupBox_buy_sell.Controls.Add(this.button_buy);
            this.groupBox_buy_sell.Controls.Add(this.button_sell);
            this.groupBox_buy_sell.Controls.Add(this.label_amount);
            this.groupBox_buy_sell.Controls.Add(this.label_buySellPrice);
            this.groupBox_buy_sell.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox_buy_sell.Location = new System.Drawing.Point(353, 50);
            this.groupBox_buy_sell.Name = "groupBox_buy_sell";
            this.groupBox_buy_sell.Size = new System.Drawing.Size(237, 148);
            this.groupBox_buy_sell.TabIndex = 6;
            this.groupBox_buy_sell.TabStop = false;
            this.groupBox_buy_sell.Text = "Buy/Sell";
            // 
            // textBox_amount
            // 
            this.textBox_amount.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_amount.Location = new System.Drawing.Point(84, 73);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.Size = new System.Drawing.Size(141, 28);
            this.textBox_amount.TabIndex = 5;
            // 
            // textBox_price
            // 
            this.textBox_price.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_price.Location = new System.Drawing.Point(84, 36);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(141, 28);
            this.textBox_price.TabIndex = 4;
            // 
            // button_buy
            // 
            this.button_buy.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_buy.Location = new System.Drawing.Point(138, 111);
            this.button_buy.Name = "button_buy";
            this.button_buy.Size = new System.Drawing.Size(87, 28);
            this.button_buy.TabIndex = 3;
            this.button_buy.Text = "Buy";
            this.button_buy.UseVisualStyleBackColor = true;
            // 
            // button_sell
            // 
            this.button_sell.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_sell.Location = new System.Drawing.Point(6, 110);
            this.button_sell.Name = "button_sell";
            this.button_sell.Size = new System.Drawing.Size(87, 28);
            this.button_sell.TabIndex = 2;
            this.button_sell.Text = "Sell";
            this.button_sell.UseVisualStyleBackColor = true;
            // 
            // label_amount
            // 
            this.label_amount.AutoSize = true;
            this.label_amount.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_amount.Location = new System.Drawing.Point(6, 76);
            this.label_amount.Name = "label_amount";
            this.label_amount.Size = new System.Drawing.Size(72, 21);
            this.label_amount.TabIndex = 1;
            this.label_amount.Text = "Amount";
            // 
            // label_buySellPrice
            // 
            this.label_buySellPrice.AutoSize = true;
            this.label_buySellPrice.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_buySellPrice.Location = new System.Drawing.Point(6, 39);
            this.label_buySellPrice.Name = "label_buySellPrice";
            this.label_buySellPrice.Size = new System.Drawing.Size(47, 21);
            this.label_buySellPrice.TabIndex = 0;
            this.label_buySellPrice.Text = "Price";
            // 
            // label_exchange_history
            // 
            this.label_exchange_history.AutoSize = true;
            this.label_exchange_history.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_exchange_history.Location = new System.Drawing.Point(12, 320);
            this.label_exchange_history.Name = "label_exchange_history";
            this.label_exchange_history.Size = new System.Drawing.Size(173, 27);
            this.label_exchange_history.TabIndex = 8;
            this.label_exchange_history.Text = "Exchange history";
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_price.Location = new System.Drawing.Point(353, 26);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(90, 21);
            this.label_price.TabIndex = 16;
            this.label_price.Text = "label_Price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_change_in_24_hour);
            this.groupBox1.Controls.Add(this.label_highest_price);
            this.groupBox1.Controls.Add(this.label_volume);
            this.groupBox1.Controls.Add(this.label_lowest_price);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(158, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 148);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "24 hour statistics";
            // 
            // label_change_in_24_hour
            // 
            this.label_change_in_24_hour.AutoSize = true;
            this.label_change_in_24_hour.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_change_in_24_hour.Location = new System.Drawing.Point(6, 39);
            this.label_change_in_24_hour.Name = "label_change_in_24_hour";
            this.label_change_in_24_hour.Size = new System.Drawing.Size(152, 21);
            this.label_change_in_24_hour.TabIndex = 2;
            this.label_change_in_24_hour.Text = "Change in 24 hour";
            // 
            // label_highest_price
            // 
            this.label_highest_price.AutoSize = true;
            this.label_highest_price.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_highest_price.Location = new System.Drawing.Point(6, 66);
            this.label_highest_price.Name = "label_highest_price";
            this.label_highest_price.Size = new System.Drawing.Size(110, 21);
            this.label_highest_price.TabIndex = 3;
            this.label_highest_price.Text = "Highest price";
            // 
            // label_volume
            // 
            this.label_volume.AutoSize = true;
            this.label_volume.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_volume.Location = new System.Drawing.Point(6, 120);
            this.label_volume.Name = "label_volume";
            this.label_volume.Size = new System.Drawing.Size(69, 21);
            this.label_volume.TabIndex = 5;
            this.label_volume.Text = "Volume";
            // 
            // label_lowest_price
            // 
            this.label_lowest_price.AutoSize = true;
            this.label_lowest_price.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_lowest_price.Location = new System.Drawing.Point(6, 93);
            this.label_lowest_price.Name = "label_lowest_price";
            this.label_lowest_price.Size = new System.Drawing.Size(105, 21);
            this.label_lowest_price.TabIndex = 4;
            this.label_lowest_price.Text = "Lowest price";
            // 
            // label_Symbol
            // 
            this.label_Symbol.AutoSize = true;
            this.label_Symbol.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Symbol.Location = new System.Drawing.Point(158, 20);
            this.label_Symbol.Name = "label_Symbol";
            this.label_Symbol.Size = new System.Drawing.Size(148, 27);
            this.label_Symbol.TabIndex = 15;
            this.label_Symbol.Text = "Symbol Name";
            // 
            // label_api_secret
            // 
            this.label_api_secret.AutoSize = true;
            this.label_api_secret.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_api_secret.Location = new System.Drawing.Point(12, 93);
            this.label_api_secret.Name = "label_api_secret";
            this.label_api_secret.Size = new System.Drawing.Size(85, 21);
            this.label_api_secret.TabIndex = 10;
            this.label_api_secret.Text = "Api secret";
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Location = new System.Drawing.Point(4, 204);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(586, 113);
            this.richTextBox_log.TabIndex = 14;
            this.richTextBox_log.Text = string.Empty;
            // 
            // textBox_api_key
            // 
            this.textBox_api_key.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_api_key.Location = new System.Drawing.Point(12, 54);
            this.textBox_api_key.Name = "textBox_api_key";
            this.textBox_api_key.PasswordChar = '*';
            this.textBox_api_key.Size = new System.Drawing.Size(140, 28);
            this.textBox_api_key.TabIndex = 11;
            // 
            // buttonSetApiCredentials
            // 
            this.buttonSetApiCredentials.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSetApiCredentials.Location = new System.Drawing.Point(65, 170);
            this.buttonSetApiCredentials.Name = "buttonSetApiCredentials";
            this.buttonSetApiCredentials.Size = new System.Drawing.Size(87, 28);
            this.buttonSetApiCredentials.TabIndex = 13;
            this.buttonSetApiCredentials.Text = "OK";
            this.buttonSetApiCredentials.UseVisualStyleBackColor = true;
            this.buttonSetApiCredentials.Click += new System.EventHandler(this.buttonSetApiCredentials_Click);
            // 
            // textBox_api_secret
            // 
            this.textBox_api_secret.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_api_secret.Location = new System.Drawing.Point(12, 126);
            this.textBox_api_secret.Name = "textBox_api_secret";
            this.textBox_api_secret.PasswordChar = '*';
            this.textBox_api_secret.Size = new System.Drawing.Size(140, 28);
            this.textBox_api_secret.TabIndex = 12;
            // 
            // Form_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.splitContainer_Demo);
            this.Name = "Form_Demo";
            this.Text = "Form_Demo";
            this.Load += new System.EventHandler(this.Form_Demo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Symbol)).EndInit();
            this.splitContainer_Demo.Panel1.ResumeLayout(false);
            this.splitContainer_Demo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Demo)).EndInit();
            this.splitContainer_Demo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_exchangeHistory)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox_buy_sell.ResumeLayout(false);
            this.groupBox_buy_sell.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer splitContainer_Demo;
        private Label label_exchange_history;
        private GroupBox groupBox1;
        private Label label_change_in_24_hour;
        private Label label_highest_price;
        private Label label_volume;
        private Label label_lowest_price;
        private GroupBox groupBox_buy_sell;
        private TextBox textBox_amount;
        private TextBox textBox_price;
        private Button button_buy;
        private Button button_sell;
        private Label label_amount;
        private Label label_buySellPrice;
        private DataGridView dataGridView_Symbol;
        private TextBox textBox_api_secret;
        private TextBox textBox_api_key;
        private Label label_api_secret;
        private Label label_api_key;
        private Button buttonSetApiCredentials;
        private RichTextBox richTextBox_log;
        private Label label_price;
        private Label label_Symbol;
        private DataGridView dataGridView_exchangeHistory;
        private Button button_search;
        private TextBox textBox_search;
        private Splitter splitter1;
        private Panel panel1;
        private Splitter splitter2;
        private Panel panel2;
    }
}