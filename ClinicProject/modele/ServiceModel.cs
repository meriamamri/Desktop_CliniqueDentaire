using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicProject.modele
{
  public  class ServiceModel
    {

        public int ServiceID { get; set; }

        public string ServiceNom { get; set; }

        public ICollection<Medecin> Medecin { get; set; }
    }

}
