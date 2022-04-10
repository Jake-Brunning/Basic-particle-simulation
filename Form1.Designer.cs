
namespace Physics_simulation
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.GlobalTimer = new System.Windows.Forms.Timer(this.components);
            this.AddParticle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GlobalTimer
            // 
            this.GlobalTimer.Interval = 20;
            this.GlobalTimer.Tick += new System.EventHandler(this.GlobalTimer_Tick);
            // 
            // AddParticle
            // 
            this.AddParticle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddParticle.ForeColor = System.Drawing.Color.Red;
            this.AddParticle.Location = new System.Drawing.Point(932, 382);
            this.AddParticle.Name = "AddParticle";
            this.AddParticle.Size = new System.Drawing.Size(138, 70);
            this.AddParticle.TabIndex = 0;
            this.AddParticle.Text = "Add Particle";
            this.AddParticle.UseVisualStyleBackColor = false;
            this.AddParticle.Click += new System.EventHandler(this.AddParticle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1273, 596);
            this.Controls.Add(this.AddParticle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GlobalTimer;
        private System.Windows.Forms.Button AddParticle;
    }
}

