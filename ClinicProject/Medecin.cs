using ClinicProject.modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicProject
{
    public partial class Medecin : Form
    {
        MedecinModel mdc=new MedecinModel();
        public Medecin(int id)
        {

            InitializeComponent();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Medecin/get/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), mdc);
                MessageBox.Show("Bonjour " + mdc.MedecinNom + " " + mdc.MedecinPrenom);
            }
            else
                mdc = null;

        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            if(mdc!=null)
            { 
                if(!panel.Controls.Contains(RendezVous._instance))
                {
                    panel.Controls.Clear();
                    panel.Controls.Add(new RendezVous(mdc.MedecinID));
                    RendezVous._instance.Dock = DockStyle.Fill;
                    RendezVous._instance.BringToFront();
                

                }
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

     
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Medecin_Load(object sender, EventArgs e)
        {

        }
    }
}
