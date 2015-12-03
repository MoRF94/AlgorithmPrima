namespace AlgorithmPrima
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox_Graph = new System.Windows.Forms.PictureBox();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.button_Run = new System.Windows.Forms.Button();
            this.timer_UpdateInfo = new System.Windows.Forms.Timer(this.components);
            this.button_New = new System.Windows.Forms.Button();
            this.button_SaveAs = new System.Windows.Forms.Button();
            this.button_Open = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Graph
            // 
            this.pictureBox_Graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Graph.Location = new System.Drawing.Point(13, 13);
            this.pictureBox_Graph.Name = "pictureBox_Graph";
            this.pictureBox_Graph.Size = new System.Drawing.Size(627, 579);
            this.pictureBox_Graph.TabIndex = 0;
            this.pictureBox_Graph.TabStop = false;
            this.pictureBox_Graph.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Graph_Paint);
            this.pictureBox_Graph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Graph_MouseClick);
            this.pictureBox_Graph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Graph_MouseDown);
            this.pictureBox_Graph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Graph_MouseMove);
            this.pictureBox_Graph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Graph_MouseUp);
            // 
            // textBox_Log
            // 
            this.textBox_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Log.Location = new System.Drawing.Point(657, 13);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ReadOnly = true;
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(347, 579);
            this.textBox_Log.TabIndex = 1;
            // 
            // button_Run
            // 
            this.button_Run.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Run.Location = new System.Drawing.Point(13, 609);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(98, 53);
            this.button_Run.TabIndex = 2;
            this.button_Run.Text = "Run!";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // timer_UpdateInfo
            // 
            this.timer_UpdateInfo.Enabled = true;
            this.timer_UpdateInfo.Tick += new System.EventHandler(this.timer_UpdateInfo_Tick);
            // 
            // button_New
            // 
            this.button_New.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.button_New.Location = new System.Drawing.Point(126, 609);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(98, 53);
            this.button_New.TabIndex = 3;
            this.button_New.Text = "New";
            this.button_New.UseVisualStyleBackColor = true;
            this.button_New.Click += new System.EventHandler(this.button_New_Click);
            // 
            // button_SaveAs
            // 
            this.button_SaveAs.Enabled = false;
            this.button_SaveAs.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button_SaveAs.Location = new System.Drawing.Point(242, 609);
            this.button_SaveAs.Name = "button_SaveAs";
            this.button_SaveAs.Size = new System.Drawing.Size(98, 53);
            this.button_SaveAs.TabIndex = 4;
            this.button_SaveAs.Text = "Save as";
            this.button_SaveAs.UseVisualStyleBackColor = true;
            this.button_SaveAs.Click += new System.EventHandler(this.button_SaveAs_Click);
            // 
            // button_Open
            // 
            this.button_Open.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button_Open.Location = new System.Drawing.Point(359, 609);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(98, 53);
            this.button_Open.TabIndex = 5;
            this.button_Open.Text = "Open";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 674);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.button_SaveAs);
            this.Controls.Add(this.button_New);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.pictureBox_Graph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algorithm Prima by MoRF";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Graph;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Timer timer_UpdateInfo;
        private System.Windows.Forms.Button button_New;
        private System.Windows.Forms.Button button_SaveAs;
        private System.Windows.Forms.Button button_Open;
    }
}

