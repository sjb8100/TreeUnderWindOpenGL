﻿namespace TreeForDen
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
            this.SOGIControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SOGIControl
            // 
            this.SOGIControl.AccumBits = ((byte)(0));
            this.SOGIControl.AutoCheckErrors = false;
            this.SOGIControl.AutoFinish = false;
            this.SOGIControl.AutoMakeCurrent = true;
            this.SOGIControl.AutoSwapBuffers = true;
            this.SOGIControl.BackColor = System.Drawing.Color.Black;
            this.SOGIControl.ColorBits = ((byte)(32));
            this.SOGIControl.DepthBits = ((byte)(16));
            this.SOGIControl.Location = new System.Drawing.Point(9, 7);
            this.SOGIControl.Name = "SOGIControl";
            this.SOGIControl.Size = new System.Drawing.Size(432, 427);
            this.SOGIControl.StencilBits = ((byte)(0));
            this.SOGIControl.TabIndex = 0;
            this.SOGIControl.Load += new System.EventHandler(this.SOGIControl_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Визуализировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(448, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Выйти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(575, 446);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SOGIControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "tree_demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl SOGIControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

