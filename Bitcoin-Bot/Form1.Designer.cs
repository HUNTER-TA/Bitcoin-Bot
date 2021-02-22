
namespace Bitcoin_Bot
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.groupBoxMarketOrder = new System.Windows.Forms.GroupBox();
            this.buttonMarketOrder = new System.Windows.Forms.Button();
            this.numericUpDownMarketOrder = new System.Windows.Forms.NumericUpDown();
            this.labelMarketOrder = new System.Windows.Forms.Label();
            this.groupBoxCheckOrderFromID = new System.Windows.Forms.GroupBox();
            this.textBoxCheckOrderFromID = new System.Windows.Forms.TextBox();
            this.buttonCheckOrderFromID = new System.Windows.Forms.Button();
            this.labelCheckOrderFromID = new System.Windows.Forms.Label();
            this.groupBoxSpecialOrderBuyBuy = new System.Windows.Forms.GroupBox();
            this.textBoxSpecialOrderBuyBuy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSpecialOrderBuyBuy = new System.Windows.Forms.Button();
            this.numericUpDownSpecialOrderBuyBuy = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTrackDeals = new System.Windows.Forms.DataGridView();
            this.child_order_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.child_order_acceptance_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.child_order_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.side = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.child_order_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxMarketOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarketOrder)).BeginInit();
            this.groupBoxCheckOrderFromID.SuspendLayout();
            this.groupBoxSpecialOrderBuyBuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpecialOrderBuyBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrackDeals)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 135);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(776, 139);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(659, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrice.Location = new System.Drawing.Point(618, 26);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(104, 16);
            this.labelPrice.TabIndex = 2;
            this.labelPrice.Text = "最終取引価格";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrice.Location = new System.Drawing.Point(621, 45);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(151, 23);
            this.textBoxPrice.TabIndex = 3;
            // 
            // groupBoxMarketOrder
            // 
            this.groupBoxMarketOrder.Controls.Add(this.buttonMarketOrder);
            this.groupBoxMarketOrder.Controls.Add(this.numericUpDownMarketOrder);
            this.groupBoxMarketOrder.Controls.Add(this.labelMarketOrder);
            this.groupBoxMarketOrder.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxMarketOrder.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMarketOrder.Name = "groupBoxMarketOrder";
            this.groupBoxMarketOrder.Size = new System.Drawing.Size(304, 56);
            this.groupBoxMarketOrder.TabIndex = 4;
            this.groupBoxMarketOrder.TabStop = false;
            this.groupBoxMarketOrder.Text = "成行注文";
            // 
            // buttonMarketOrder
            // 
            this.buttonMarketOrder.Location = new System.Drawing.Point(223, 27);
            this.buttonMarketOrder.Name = "buttonMarketOrder";
            this.buttonMarketOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonMarketOrder.TabIndex = 2;
            this.buttonMarketOrder.Text = "発注";
            this.buttonMarketOrder.UseVisualStyleBackColor = true;
            this.buttonMarketOrder.Click += new System.EventHandler(this.buttonMarketOrder_Click);
            // 
            // numericUpDownMarketOrder
            // 
            this.numericUpDownMarketOrder.DecimalPlaces = 3;
            this.numericUpDownMarketOrder.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownMarketOrder.Location = new System.Drawing.Point(97, 26);
            this.numericUpDownMarketOrder.Name = "numericUpDownMarketOrder";
            this.numericUpDownMarketOrder.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownMarketOrder.TabIndex = 1;
            this.numericUpDownMarketOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // labelMarketOrder
            // 
            this.labelMarketOrder.AutoSize = true;
            this.labelMarketOrder.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMarketOrder.Location = new System.Drawing.Point(18, 26);
            this.labelMarketOrder.Name = "labelMarketOrder";
            this.labelMarketOrder.Size = new System.Drawing.Size(72, 16);
            this.labelMarketOrder.TabIndex = 0;
            this.labelMarketOrder.Text = "注文枚数";
            // 
            // groupBoxCheckOrderFromID
            // 
            this.groupBoxCheckOrderFromID.Controls.Add(this.textBoxCheckOrderFromID);
            this.groupBoxCheckOrderFromID.Controls.Add(this.buttonCheckOrderFromID);
            this.groupBoxCheckOrderFromID.Controls.Add(this.labelCheckOrderFromID);
            this.groupBoxCheckOrderFromID.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxCheckOrderFromID.Location = new System.Drawing.Point(12, 74);
            this.groupBoxCheckOrderFromID.Name = "groupBoxCheckOrderFromID";
            this.groupBoxCheckOrderFromID.Size = new System.Drawing.Size(304, 56);
            this.groupBoxCheckOrderFromID.TabIndex = 5;
            this.groupBoxCheckOrderFromID.TabStop = false;
            this.groupBoxCheckOrderFromID.Text = "child_order_acceptance_idから確認";
            // 
            // textBoxCheckOrderFromID
            // 
            this.textBoxCheckOrderFromID.Location = new System.Drawing.Point(46, 22);
            this.textBoxCheckOrderFromID.Name = "textBoxCheckOrderFromID";
            this.textBoxCheckOrderFromID.Size = new System.Drawing.Size(171, 23);
            this.textBoxCheckOrderFromID.TabIndex = 3;
            // 
            // buttonCheckOrderFromID
            // 
            this.buttonCheckOrderFromID.Location = new System.Drawing.Point(223, 22);
            this.buttonCheckOrderFromID.Name = "buttonCheckOrderFromID";
            this.buttonCheckOrderFromID.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckOrderFromID.TabIndex = 2;
            this.buttonCheckOrderFromID.Text = "確認";
            this.buttonCheckOrderFromID.UseVisualStyleBackColor = true;
            this.buttonCheckOrderFromID.Click += new System.EventHandler(this.buttonCheckOrderFromID_Click);
            // 
            // labelCheckOrderFromID
            // 
            this.labelCheckOrderFromID.AutoSize = true;
            this.labelCheckOrderFromID.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelCheckOrderFromID.Location = new System.Drawing.Point(18, 25);
            this.labelCheckOrderFromID.Name = "labelCheckOrderFromID";
            this.labelCheckOrderFromID.Size = new System.Drawing.Size(22, 16);
            this.labelCheckOrderFromID.TabIndex = 0;
            this.labelCheckOrderFromID.Text = "ID";
            // 
            // groupBoxSpecialOrderBuyBuy
            // 
            this.groupBoxSpecialOrderBuyBuy.Controls.Add(this.textBoxSpecialOrderBuyBuy);
            this.groupBoxSpecialOrderBuyBuy.Controls.Add(this.label2);
            this.groupBoxSpecialOrderBuyBuy.Controls.Add(this.buttonSpecialOrderBuyBuy);
            this.groupBoxSpecialOrderBuyBuy.Controls.Add(this.numericUpDownSpecialOrderBuyBuy);
            this.groupBoxSpecialOrderBuyBuy.Controls.Add(this.label1);
            this.groupBoxSpecialOrderBuyBuy.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxSpecialOrderBuyBuy.Location = new System.Drawing.Point(356, 12);
            this.groupBoxSpecialOrderBuyBuy.Name = "groupBoxSpecialOrderBuyBuy";
            this.groupBoxSpecialOrderBuyBuy.Size = new System.Drawing.Size(228, 117);
            this.groupBoxSpecialOrderBuyBuy.TabIndex = 6;
            this.groupBoxSpecialOrderBuyBuy.TabStop = false;
            this.groupBoxSpecialOrderBuyBuy.Text = "特殊注文：買々";
            // 
            // textBoxSpecialOrderBuyBuy
            // 
            this.textBoxSpecialOrderBuyBuy.Location = new System.Drawing.Point(97, 23);
            this.textBoxSpecialOrderBuyBuy.Name = "textBoxSpecialOrderBuyBuy";
            this.textBoxSpecialOrderBuyBuy.Size = new System.Drawing.Size(120, 23);
            this.textBoxSpecialOrderBuyBuy.TabIndex = 8;
            this.textBoxSpecialOrderBuyBuy.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "間隔";
            // 
            // buttonSpecialOrderBuyBuy
            // 
            this.buttonSpecialOrderBuyBuy.Location = new System.Drawing.Point(142, 81);
            this.buttonSpecialOrderBuyBuy.Name = "buttonSpecialOrderBuyBuy";
            this.buttonSpecialOrderBuyBuy.Size = new System.Drawing.Size(75, 23);
            this.buttonSpecialOrderBuyBuy.TabIndex = 2;
            this.buttonSpecialOrderBuyBuy.Text = "発注";
            this.buttonSpecialOrderBuyBuy.UseVisualStyleBackColor = true;
            this.buttonSpecialOrderBuyBuy.Click += new System.EventHandler(this.buttonSpecialOrderBuyBuy_Click);
            // 
            // numericUpDownSpecialOrderBuyBuy
            // 
            this.numericUpDownSpecialOrderBuyBuy.DecimalPlaces = 3;
            this.numericUpDownSpecialOrderBuyBuy.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownSpecialOrderBuyBuy.Location = new System.Drawing.Point(97, 52);
            this.numericUpDownSpecialOrderBuyBuy.Name = "numericUpDownSpecialOrderBuyBuy";
            this.numericUpDownSpecialOrderBuyBuy.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownSpecialOrderBuyBuy.TabIndex = 1;
            this.numericUpDownSpecialOrderBuyBuy.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(19, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "枚数";
            // 
            // dataGridViewTrackDeals
            // 
            this.dataGridViewTrackDeals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrackDeals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.child_order_date,
            this.child_order_acceptance_id,
            this.child_order_state,
            this.side,
            this.child_order_type,
            this.price,
            this.size});
            this.dataGridViewTrackDeals.Location = new System.Drawing.Point(12, 288);
            this.dataGridViewTrackDeals.Name = "dataGridViewTrackDeals";
            this.dataGridViewTrackDeals.RowTemplate.Height = 21;
            this.dataGridViewTrackDeals.Size = new System.Drawing.Size(776, 150);
            this.dataGridViewTrackDeals.TabIndex = 7;
            // 
            // child_order_date
            // 
            this.child_order_date.HeaderText = "取引日時";
            this.child_order_date.Name = "child_order_date";
            // 
            // child_order_acceptance_id
            // 
            this.child_order_acceptance_id.HeaderText = "注文ID";
            this.child_order_acceptance_id.Name = "child_order_acceptance_id";
            // 
            // child_order_state
            // 
            this.child_order_state.HeaderText = "注文状態";
            this.child_order_state.Name = "child_order_state";
            // 
            // side
            // 
            this.side.HeaderText = "売買";
            this.side.Name = "side";
            // 
            // child_order_type
            // 
            this.child_order_type.HeaderText = "注文種類";
            this.child_order_type.Name = "child_order_type";
            // 
            // price
            // 
            this.price.HeaderText = "価格";
            this.price.Name = "price";
            // 
            // size
            // 
            this.size.HeaderText = "枚数";
            this.size.Name = "size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewTrackDeals);
            this.Controls.Add(this.groupBoxSpecialOrderBuyBuy);
            this.Controls.Add(this.groupBoxCheckOrderFromID);
            this.Controls.Add(this.groupBoxMarketOrder);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxMarketOrder.ResumeLayout(false);
            this.groupBoxMarketOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarketOrder)).EndInit();
            this.groupBoxCheckOrderFromID.ResumeLayout(false);
            this.groupBoxCheckOrderFromID.PerformLayout();
            this.groupBoxSpecialOrderBuyBuy.ResumeLayout(false);
            this.groupBoxSpecialOrderBuyBuy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpecialOrderBuyBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrackDeals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBoxMarketOrder;
        private System.Windows.Forms.Button buttonMarketOrder;
        private System.Windows.Forms.NumericUpDown numericUpDownMarketOrder;
        private System.Windows.Forms.Label labelMarketOrder;
        private System.Windows.Forms.GroupBox groupBoxCheckOrderFromID;
        private System.Windows.Forms.TextBox textBoxCheckOrderFromID;
        private System.Windows.Forms.Button buttonCheckOrderFromID;
        private System.Windows.Forms.Label labelCheckOrderFromID;
        private System.Windows.Forms.GroupBox groupBoxSpecialOrderBuyBuy;
        private System.Windows.Forms.TextBox textBoxSpecialOrderBuyBuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSpecialOrderBuyBuy;
        private System.Windows.Forms.NumericUpDown numericUpDownSpecialOrderBuyBuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTrackDeals;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_order_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_order_acceptance_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_order_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn side;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_order_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
    }
}

