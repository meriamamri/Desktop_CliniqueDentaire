namespace ClinicProject
{
    partial class Medecin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Medecin));
            this.btn_rendezvous = new System.Windows.Forms.Button();
            this.btn_patients = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_services = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_rendezvous
            // 
            this.btn_rendezvous.FlatAppearance.BorderSize = 0;
            this.btn_rendezvous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rendezvous.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rendezvous.ForeColor = System.Drawing.Color.White;
            this.btn_rendezvous.Image = ((System.Drawing.Image)(resources.GetObject("btn_rendezvous.Image")));
            this.btn_rendezvous.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_rendezvous.Location = new System.Drawing.Point(12, 156);
            this.btn_rendezvous.Name = "btn_rendezvous";
            this.btn_rendezvous.Size = new System.Drawing.Size(216, 59);
            this.btn_rendezvous.TabIndex = 2;
            this.btn_rendezvous.Text = "    Plannification      d\'aujourd\'hui";
            this.btn_rendezvous.UseVisualStyleBackColor = true;
            this.btn_rendezvous.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_patients
            // 
            this.btn_patients.FlatAppearance.BorderSize = 0;
            this.btn_patients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_patients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_patients.ForeColor = System.Drawing.Color.White;
            this.btn_patients.Image = ((System.Drawing.Image)(resources.GetObject("btn_patients.Image")));
            this.btn_patients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_patients.Location = new System.Drawing.Point(12, 221);
            this.btn_patients.Name = "btn_patients";
            this.btn_patients.Size = new System.Drawing.Size(216, 59);
            this.btn_patients.TabIndex = 3;
            this.btn_patients.Text = "     Liste de rendez-vous";
            this.btn_patients.UseVisualStyleBackColor = true;
            this.btn_patients.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.btn_services);
            this.panel3.Controls.Add(this.btn_patients);
            this.panel3.Controls.Add(this.btn_rendezvous);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 599);
            this.panel3.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Location = new System.Drawing.Point(1, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 62);
            this.panel1.TabIndex = 5;
            // 
            // btn_services
            // 
            this.btn_services.FlatAppearance.BorderSize = 0;
            this.btn_services.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_services.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_services.ForeColor = System.Drawing.Color.White;
            this.btn_services.Image = ((System.Drawing.Image)(resources.GetObject("btn_services.Image")));
            this.btn_services.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_services.Location = new System.Drawing.Point(12, 286);
            this.btn_services.Name = "btn_services";
            this.btn_services.Size = new System.Drawing.Size(216, 59);
            this.btn_services.TabIndex = 4;
            this.btn_services.Text = "Liste de patients";
            this.btn_services.UseVisualStyleBackColor = true;
            this.btn_services.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(228, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(825, 587);
            this.panel.TabIndex = 5;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.YellowGreen;
            this.panel2.Location = new System.Drawing.Point(228, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 10);
            this.panel2.TabIndex = 6;
            // 
            // Medecin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1067, 638);
            this.MinimumSize = new System.Drawing.Size(1067, 638);
            this.Name = "Medecin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Medecin_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_patients;
        private System.Windows.Forms.Button btn_rendezvous;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_services;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel2;
    }
}

