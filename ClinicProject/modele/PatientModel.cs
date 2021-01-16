using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicProject.modele
{
  public  class PatientModel
    {
        public int PatientID { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }
        public string tel { get; set; }
        public string carteSoin { get; set; }
        public DateTime? DateNaissance { get; set; }




        public int? UserID { get; set; }
      
        public virtual UserModel UserAccount { get; set; }
<<<<<<< HEAD
        public string Name { get; internal set; }
        public int Id { get; internal set; }
=======


        public string NomPrenom
        {
            get { return Nom + " " + Prenom; }
        }
>>>>>>> f81c58056485a14ab3054dc36a0cbae4615fcbf6
    }
}
