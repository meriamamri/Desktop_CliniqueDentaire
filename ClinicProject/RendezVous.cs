using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Net.Http;
using ClinicProject.modele;

namespace ClinicProject
{
    public partial class RendezVous : UserControl
    {
        int idMdc;
        List<RdvModel>  rendez;
        public static RendezVous instance;
        public static RendezVous _instance
        {
            get
                { if(instance==null)
            {
                instance = new RendezVous(0);
            }
            return instance;
            }
           

        }
        public RendezVous(int id)
        {
            idMdc = id;
            InitializeComponent();
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Rdvs/Medecin/" + idMdc).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var rdv=new List<RdvModel>();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(),rdv);
                rendez = rdv;
                DataTable dt = new DataTable("dataGridView1");
                dt.Columns.Add(new DataColumn("Heure debut", typeof(string)));
                dt.Columns.Add(new DataColumn("Heure fin", typeof(string)));
                dt.Columns.Add(new DataColumn("Nom patient", typeof(String)));
                dt.Columns.Add(new DataColumn("Prénom patient", typeof(String)));

                

                foreach (var rendez in rdv)
                {
                    DataRow tr = dt.NewRow();
                    tr["Heure debut"] = ((DateTime)rendez.Hdebut).ToString("HH:mm");
                    tr["Heure fin"] = ((DateTime)rendez.Hfin).ToString("HH:mm");
                    tr["Nom patient"] = rendez.Patient.Nom;
                    tr["Prénom patient"] = rendez.Patient.Prenom;
                    dt.Rows.Add(tr);
                }
            
                 metroGrid1.DataSource = dt;
            }



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void RendezVous_Load(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int g=metroGrid1.CurrentCell.RowIndex;
  
            FichePatient second = new FichePatient(idMdc,(int)rendez[g].PatientID);
            this.Hide();
            this.Parent.Controls.Add(second);


        }
    }
}
