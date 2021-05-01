
namespace _2048WindowsFormsApp
{
    partial class GameTypeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button4X4 = new System.Windows.Forms.Button();
            this.button5X5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите игру";
            // 
            // button4X4
            // 
            this.button4X4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button4X4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4X4.Location = new System.Drawing.Point(59, 102);
            this.button4X4.Name = "button4X4";
            this.button4X4.Size = new System.Drawing.Size(136, 125);
            this.button4X4.TabIndex = 1;
            this.button4X4.Text = "4 х 4";
            this.button4X4.UseVisualStyleBackColor = true;
            this.button4X4.Click += new System.EventHandler(this.button4X4_Click);
            // 
            // button5X5
            // 
            this.button5X5.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button5X5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5X5.Location = new System.Drawing.Point(59, 271);
            this.button5X5.Name = "button5X5";
            this.button5X5.Size = new System.Drawing.Size(136, 125);
            this.button5X5.TabIndex = 2;
            this.button5X5.Text = "5 х 5";
            this.button5X5.UseVisualStyleBackColor = true;
            this.button5X5.Click += new System.EventHandler(this.button5X5_Click);
            // 
            // GameTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 450);
            this.Controls.Add(this.button5X5);
            this.Controls.Add(this.button4X4);
            this.Controls.Add(this.label1);
            this.Name = "GameTypeForm";
            this.Text = "Выбор игры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameTypeForm_FormClosing);
            this.Load += new System.EventHandler(this.GameTypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4X4;
        private System.Windows.Forms.Button button5X5;
    }
}