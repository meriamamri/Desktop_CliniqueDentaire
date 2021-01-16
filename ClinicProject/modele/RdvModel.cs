using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicProject.modele
{
   public class RdvModel
    {
        public int RdvID { get; set; }


    
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Date")]
        public DateTime? Date { get; set; }

      
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true), Display(Name = "Hdebut")]
        public DateTime? Hdebut { get; set; }

       
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true), Display(Name = "Hfin")]
        public DateTime? Hfin { get; set; }

        [Required]
        public int? PatientID { get; set; }

        
        public virtual PatientModel Patient { get; set; }

        [Required]
        public int? MedecinID { get; set; }

        public virtual MedecinModel Medecin { get; set; }
    }
}
