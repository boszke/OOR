﻿namespace Thread1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.red_btn = new System.Windows.Forms.Button();
            this.green_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.blue_btn = new System.Windows.Forms.Button();
            this.orange_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // red_btn
            // 
            this.red_btn.Location = new System.Drawing.Point(13, 13);
            this.red_btn.Name = "red_btn";
            this.red_btn.Size = new System.Drawing.Size(75, 23);
            this.red_btn.TabIndex = 0;
            this.red_btn.Text = "Czerwony";
            this.red_btn.UseVisualStyleBackColor = true;
            this.red_btn.Click += new System.EventHandler(this.red_btn_Click);
            // 
            // green_btn
            // 
            this.green_btn.Location = new System.Drawing.Point(13, 43);
            this.green_btn.Name = "green_btn";
            this.green_btn.Size = new System.Drawing.Size(75, 23);
            this.green_btn.TabIndex = 1;
            this.green_btn.Text = "Zielony";
            this.green_btn.UseVisualStyleBackColor = true;
            this.green_btn.Click += new System.EventHandler(this.green_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bez wątków:";
            // 
            // blue_btn
            // 
            this.blue_btn.Location = new System.Drawing.Point(13, 100);
            this.blue_btn.Name = "blue_btn";
            this.blue_btn.Size = new System.Drawing.Size(75, 23);
            this.blue_btn.TabIndex = 3;
            this.blue_btn.Text = "Niebieski";
            this.blue_btn.UseVisualStyleBackColor = true;
            this.blue_btn.Click += new System.EventHandler(this.blue_btn_Click);
            // 
            // orange_btn
            // 
            this.orange_btn.Location = new System.Drawing.Point(13, 129);
            this.orange_btn.Name = "orange_btn";
            this.orange_btn.Size = new System.Drawing.Size(75, 23);
            this.orange_btn.TabIndex = 4;
            this.orange_btn.Text = "Pomarańcz";
            this.orange_btn.UseVisualStyleBackColor = true;
            this.orange_btn.Click += new System.EventHandler(this.orange_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Wszystkie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(175, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 369);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(756, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Wątki:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Wątki tekstowe";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Czyść";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 394);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.orange_btn);
            this.Controls.Add(this.blue_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.green_btn);
            this.Controls.Add(this.red_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button red_btn;
        private System.Windows.Forms.Button green_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button blue_btn;
        private System.Windows.Forms.Button orange_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

