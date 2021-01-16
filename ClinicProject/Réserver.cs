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
    public partial class Réserver : Form
    {
       
        int idService;
        PatientModel patien;
        MedecinModel medec;


        public Réserver(MedecinModel m, ServiceModel s, int patientID)
        {
            InitializeComponent();

            dateTimePicker2.MinDate = DateTime.Today;
            medec = m;
            idService = s.ServiceID;


            label1.Text = s.ServiceNom;
            label2.Text = m.NomPrenom;

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Patients/"+patientID).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var p =new PatientModel();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), p);
                label8.Text = p.NomPrenom;
                patien = p;


           

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
 

            DateTime date = dateTimePicker2.Value;
            DateTime hDeb = dateTimePicker1.Value;
            DateTime hFin = dateTimePicker3.Value;


            DateTime deb = new DateTime(date.Year,date.Month,date.Day,hDeb.Hour,hDeb.Minute,hDeb.Second);


            DateTime fin = new DateTime(date.Year, date.Month, date.Day, hFin.Hour, hFin.Minute, hFin.Second);

            MessageBox.Show("date " + date.ToString() + " \n hdeby " +deb.ToString()+"\n  hFIn "+fin.ToString());

            RdvModel rd = new RdvModel();
            rd.Date = new DateTime(date.Year, date.Month, date.Day);
            rd.Hdebut=new DateTime(date.Year, date.Month, date.Day, hDeb.Hour, hDeb.Minute, hDeb.Second);
            rd.Hfin= new DateTime(date.Year, date.Month, date.Day, hFin.Hour, hFin.Minute, hFin.Second);
            rd.MedecinID = medec.MedecinID;
            rd.PatientID = patien.PatientID;
     

            var client = new HttpClient();



            client.BaseAddress = new Uri("http://localhost:61585/api");
         
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            /*
                        var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(rd);
                        var httpContent = new StringContent(myContent);
                        */
            var response = client.PostAsJsonAsync(client.BaseAddress + "/Rdvs", rd).Result;

            if (response.IsSuccessStatusCode)
            {
               
                MessageBox.Show("succés");
               

            }
            else MessageBox.Show("echec");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker3.MinDate = dateTimePicker1.Value;
        }
    }
}
