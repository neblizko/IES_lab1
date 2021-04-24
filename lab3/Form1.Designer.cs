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
            this.fermButton = new System.Windows.Forms.Button();
            this.fermInput = new System.Windows.Forms.TextBox();
            this.fermResult = new System.Windows.Forms.Label();
            this.percSigma = new System.Windows.Forms.TextBox();
            this.percButton = new System.Windows.Forms.Button();
            this.percResult = new System.Windows.Forms.Label();
            this.percIterations = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fermButton
            // 
            this.fermButton.Location = new System.Drawing.Point(12, 40);
            this.fermButton.Name = "fermButton";
            this.fermButton.Size = new System.Drawing.Size(75, 23);
            this.fermButton.TabIndex = 0;
            this.fermButton.Text = "Count";
            this.fermButton.UseVisualStyleBackColor = true;
            this.fermButton.Click += new System.EventHandler(this.fermButton_Click);
            // 
            // fermInput
            // 
            this.fermInput.Location = new System.Drawing.Point(12, 12);
            this.fermInput.Name = "fermInput";
            this.fermInput.Size = new System.Drawing.Size(75, 22);
            this.fermInput.TabIndex = 1;
            // 
            // fermResult
            // 
            this.fermResult.AutoSize = true;
            this.fermResult.Location = new System.Drawing.Point(12, 66);
            this.fermResult.Name = "fermResult";
            this.fermResult.Size = new System.Drawing.Size(0, 17);
            this.fermResult.TabIndex = 2;
            // 
            // percSigma
            // 
            this.percSigma.Location = new System.Drawing.Point(172, 13);
            this.percSigma.Name = "percSigma";
            this.percSigma.Size = new System.Drawing.Size(100, 22);
            this.percSigma.TabIndex = 3;
            // 
            // percButton
            // 
            this.percButton.Location = new System.Drawing.Point(173, 65);
            this.percButton.Name = "percButton";
            this.percButton.Size = new System.Drawing.Size(100, 23);
            this.percButton.TabIndex = 4;
            this.percButton.Text = "Train";
            this.percButton.UseVisualStyleBackColor = true;
            this.percButton.Click += new System.EventHandler(this.percButton_Click);
            // 
            // percResult
            // 
            this.percResult.AutoSize = true;
            this.percResult.Location = new System.Drawing.Point(170, 96);
            this.percResult.Name = "percResult";
            this.percResult.Size = new System.Drawing.Size(46, 17);
            this.percResult.TabIndex = 5;
            this.percResult.Text = "label1";
            // 
            // percIterations
            // 
            this.percIterations.Location = new System.Drawing.Point(172, 37);
            this.percIterations.Name = "percIterations";
            this.percIterations.Size = new System.Drawing.Size(100, 22);
            this.percIterations.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.percResult);
            this.Controls.Add(this.percButton);
            this.Controls.Add(this.percIterations);
            this.Controls.Add(this.percSigma);
            this.Controls.Add(this.fermResult);
            this.Controls.Add(this.fermInput);
            this.Controls.Add(this.fermButton);
            this.Name = "Form1";
            this.Text = "Lab 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fermButton;
        private System.Windows.Forms.TextBox fermInput;
        private System.Windows.Forms.Label fermResult;
        private System.Windows.Forms.TextBox percSigma;
        private System.Windows.Forms.Button percButton;
        private System.Windows.Forms.Label percResult;
        private System.Windows.Forms.TextBox percIterations;
    }
}

