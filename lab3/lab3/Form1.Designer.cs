
namespace lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.number1 = new System.Windows.Forms.TextBox();
            this.number2 = new System.Windows.Forms.TextBox();
            this.number3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // number1
            // 
            this.number1.Location = new System.Drawing.Point(41, 39);
            this.number1.Multiline = true;
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(111, 49);
            this.number1.TabIndex = 0;
            // 
            // number2
            // 
            this.number2.Location = new System.Drawing.Point(192, 40);
            this.number2.Multiline = true;
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(112, 48);
            this.number2.TabIndex = 1;
            // 
            // number3
            // 
            this.number3.Location = new System.Drawing.Point(344, 40);
            this.number3.Multiline = true;
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(112, 48);
            this.number3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 64);
            this.button1.TabIndex = 3;
            this.button1.Text = "НОД";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 64);
            this.button2.TabIndex = 4;
            this.button2.Text = "Поиск простых чисел";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(41, 224);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(415, 203);
            this.result.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(344, 120);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 64);
            this.button3.TabIndex = 6;
            this.button3.Text = "Число простое?";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.result);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.number3);
            this.Controls.Add(this.number2);
            this.Controls.Add(this.number1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox number1;
        private System.Windows.Forms.TextBox number2;
        private System.Windows.Forms.TextBox number3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button button3;
    }
}

