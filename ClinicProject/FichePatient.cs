using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using ClinicProject.modele;
using ClinicProject.RetourType;

namespace ClinicProject
{
    public partial class FichePatient : UserControl
    {
        int idMedecin;
        int idPatient;
        public FichePatient(int idMed,int idPat)
        {
            InitializeComponent();
            idMedecin = idMed;
            idPatient = idPat;

            metroDateTime1.MinDate = DateTime.Today;
            
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/services").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var services = new List<ServiceModel>();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(),services);
                DataSet ds = new DataSet();
              
                 metroComboBox2.DataSource =services;
                 metroComboBox2.ValueMember = "ServiceID";
                 metroComboBox2.DisplayMember = "ServiceNom";

            }
        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MedecinModel md = (MedecinModel)metroComboBox1.SelectedItem;
            string g = metroDateTime1.Value.Year + "-" + metroDateTime1.Value.Month + "-" + metroDateTime1.Value.Day;

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");//ywali medecin selectionne
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Rdvs/disponibilities/"+md.MedecinID+"/"+g).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var dayIntervals = new List<DayIntervals>();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(),dayIntervals);

                int i = 0;
                foreach(DayIntervals d in dayIntervals)
                {

                    Panel p = new System.Windows.Forms.Panel();
                    p.Size = new Size(152, 322);
                    p.BackColor = Color.White;

                    Panel tete = new System.Windows.Forms.Panel();
                    tete.Size = new Size(152, 63);
                    tete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));

                    Label l = new System.Windows.Forms.Label();
                    l.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
                    l.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    l.ForeColor = System.Drawing.Color.White;
                    //nom du jour i 
                    l.Text = d.day.ToString("dddd");
                    l.Location = new System.Drawing.Point(3, 4);
                    tete.Controls.Add(l);


                    Label lm = new System.Windows.Forms.Label();
                    lm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
                    lm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lm.ForeColor = System.Drawing.Color.White;
                    //date
                    lm.Text = d.day.ToString();
                    lm.Location = new System.Drawing.Point(3, 28);


                    tete.Controls.Add(lm);
                    p.Controls.Add(tete);

                    int j = 0; 
                    foreach(Interval inter in d.intervals)
                    {
                        Label lp = new Label();
                        lp.BackColor = System.Drawing.Color.DarkGray;
                        lp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        lp.ForeColor = System.Drawing.Color.White;
                        //disponbilite 
                        lp.Text = "de "+ inter.debut.ToString("HH:mm")+ " à "+inter.fin.ToString("HH:mm");
                        lp.AutoSize = true;
                        lp.Location = new System.Drawing.Point(3, 60 + (j + 1) * 28);
                        p.Controls.Add(lp);
                        j++;
                    }


                    p.Location = new System.Drawing.Point(i * 160, 0);
                    i++;
                    panel3.Controls.Add(p);
                }


                 panel3.Visible = true;
                 button1.Visible = true;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            MedecinModel md = (MedecinModel)metroComboBox1.SelectedItem;
            ServiceModel s = (ServiceModel)metroComboBox2.SelectedItem;

            Réserver r = new Réserver(md,s,idPatient);
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ProchainRDV second = new ProchainRDV();
            this.Hide();
            this.Parent.Controls.Add(second);

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceModel s = (ServiceModel) metroComboBox2.SelectedItem;
       
            ///List<MedecinModel> managementList = s.Medecin.Cast<MedecinModel>().ToList();
   

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Services/lisMedecins/"+s.ServiceID).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var medecins = new List<MedecinModel>();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), medecins);
                metroComboBox1.DataSource = medecins;
                metroComboBox1.ValueMember = "MedecinID";
                metroComboBox1.DisplayMember = "NomPrenom";
            }


        }

    }
}
