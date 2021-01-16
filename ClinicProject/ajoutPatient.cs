using ClinicProject.modele;
using ClinicProject.validators;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;


namespace ClinicProject
{
    public partial class ajoutPatient : Form
    {
        public ajoutPatient()
        {
            InitializeComponent();
        }

        private void ajoutPatient_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroDateTime3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api/");
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var user = new UserModel();
            user.Email = textBox7.Text;
             
            user.Password = BCrypt.Net.BCrypt.HashPassword(textBox6.Text);
            user.Type = "patient";
            UserValidaror validator = new UserValidaror();
            var results = validator.Validate(user);
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    label8.Visible = true;
                    label8.Text =failure.ErrorMessage;
                }
            }
            else
            {
                label8.Visible = false;

                var patient = new PatientModel();
                    patient.Nom = textBox1.Text;
                    patient.Adresse = textBox3.Text;
                    patient.Prenom = textBox2.Text;
                    patient.tel = textBox4.Text;
                    patient.carteSoin = textBox5.Text;
                    patient.DateNaissance = metroDateTime3.Value;
                    patient.UserAccount = user;
                    patient.UserID = user.UserId;
                PatientValidator valid = new PatientValidator();
                var result = valid.Validate(patient);
                var postTask = client.PostAsJsonAsync("Patients", patient);
                if (result.IsValid == false)
                {
                    foreach (ValidationFailure failure in result.Errors)
                    {
                        label8.Visible = true;
                        label8.Text = failure.ErrorMessage;
                    }
                }
                else
                {
                    label8.Visible = false;
                }


                }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
