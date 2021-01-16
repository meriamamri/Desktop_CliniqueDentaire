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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {


            /*
            MessageBox.Show(textBox1.Text+"+++ "+textBox2.Text);
            if (metroRadioButton1.Checked == true)
            {
                MessageBox.Show("You are selected medecin !! ");
                return;
            }
            else if (metroRadioButton2.Checked == true)
            {
                MessageBox.Show("You are selected secretaire !! ");
                return;
            }*/
            MessageBox.Show(textBox1.Text + "/" + textBox2.Text);
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/login/"+ textBox1.Text+"/"+textBox2.Text).Result;
            if(response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var med = new UserModel();
               
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), med);
                if(med.Type=="medecin")
                {
                    Medecin m = new Medecin(med.UserId);
                    m.Show();
                }
                    else
                      if (med.Type == "secretaire")
                {
                    Secretaire m = new Secretaire();
                    m.Show();
                }

              
                this.Hide();



            }
            else 
                MessageBox.Show("Vérifier vos cordonnées");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

