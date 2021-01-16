using ClinicProject.modele;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicProject.validators
{
    class UserValidaror : AbstractValidator<UserModel> 
    {
        public UserValidaror()
        {
            RuleFor(p=> p.Email).EmailAddress().WithMessage("veillez saisir une correcte adresse mail");
            RuleFor(p => p.Password).NotEmpty().Length(8,60);
        }
    }
}
