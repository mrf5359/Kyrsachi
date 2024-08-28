namespace Kursach3_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.numericUpDownThreads = new System.Windows.Forms.NumericUpDown();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.numericUpDownByteValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByteValue)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFilePath.Location = new System.Drawing.Point(3, 36);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(258, 22);
            this.textBoxFilePath.TabIndex = 0;
            // 
            // numericUpDownThreads
            // 
            this.numericUpDownThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownThreads.Location = new System.Drawing.Point(267, 36);
            this.numericUpDownThreads.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownThreads.Name = "numericUpDownThreads";
            this.numericUpDownThreads.Size = new System.Drawing.Size(258, 22);
            this.numericUpDownThreads.TabIndex = 1;
            this.numericUpDownThreads.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelResult, 3);
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelResult.Location = new System.Drawing.Point(3, 144);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(794, 306);
            this.labelResult.TabIndex = 2;
            this.labelResult.Text = "Результат";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonBrowse.Location = new System.Drawing.Point(3, 64);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(258, 35);
            this.buttonBrowse.TabIndex = 3;
            this.buttonBrowse.Text = "Открыть";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click_1);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonCalculate.Location = new System.Drawing.Point(3, 105);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(258, 36);
            this.buttonCalculate.TabIndex = 4;
            this.buttonCalculate.Text = "Порахувати";
            this.buttonCalculate.UseCompatibleTextRendering = true;
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click_1);
            // 
            // numericUpDownByteValue
            // 
            this.numericUpDownByteValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownByteValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownByteValue.Location = new System.Drawing.Point(531, 36);
            this.numericUpDownByteValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownByteValue.Name = "numericUpDownByteValue";
            this.numericUpDownByteValue.Size = new System.Drawing.Size(266, 22);
            this.numericUpDownByteValue.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Оберіть файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(267, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Число потоків";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(531, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Оберіть байт";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxFilePath, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonBrowse, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.numericUpDownThreads, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.numericUpDownByteValue, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonCalculate, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.labelResult, 0, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kursach3_1.Properties.Resources.Vho;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByteValue)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.NumericUpDown numericUpDownThreads;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.NumericUpDown numericUpDownByteValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}
