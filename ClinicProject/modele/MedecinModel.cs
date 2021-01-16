using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicProject.modele
{
 public   class MedecinModel
    {
        public int MedecinID { get; set; }

        public string MedecinNom { get; set; }

        public string MedecinPrenom { get; set; }

        public int? UserID { get; set; }
       
        public virtual UserModel UserAccount { get; set; }

        public string NomPrenom
        {
            get { return MedecinNom + " " + MedecinPrenom; }
        }
    }
}
