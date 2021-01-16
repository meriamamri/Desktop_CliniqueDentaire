using ClinicProject.modele;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicProject.validators
{
    class PatientValidator : AbstractValidator<PatientModel>
    {
        public PatientValidator()
        {
            RuleFor(n => n.Nom).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Nom ne doit pas etre vide")
                .Length(2, 30).WithMessage("longeur de nom doit au moins contenir deux caractere")
                .Must(validName).WithMessage("le nom doit etre alphapetique");
            RuleFor(n => n.Prenom).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("prenom ne doit pas etre vide")
                .Length(2, 30).WithMessage("longeur de prenom doit au moins contenir deux caractere")
                .Must(validName).WithMessage("le nom doit etre alphapetique");
            RuleFor(n => n.Adresse).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("adresse ne doit pas etre vide")
                .Length(5, 30).WithMessage("adresse non reconnu");
            RuleFor(n => n.tel).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("veuillez saisir le telepohne")
                .Length(8).WithMessage("numero tel invalid longeur min 8")
                .Must(validtel).WithMessage("telephone est numerique");
            RuleFor(n => n.carteSoin).Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("veuillez saisir le numero de carte de soin ")
               .Length(10).WithMessage("numero de carte de soin de 10 caractere");
            RuleFor(p => p.DateNaissance).Must(validAge);




        }

        private bool validAge(DateTime? arg)
        {
            return true;
        }

        protected bool validName (string name) {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(char.IsLetter);

        }
        protected bool validtel(string name)
        {
            return name.All(char.IsNumber);

        }
        protected bool validAge(DateTime age)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = age.Year;
            if (dobYear <= currentYear && dobYear <= (currentYear - 120))
            {
                return true;
            }
            return false; 

        }

    }
}
