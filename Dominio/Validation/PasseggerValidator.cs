using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Validation
{
    public class PasseggerValidator:AbstractValidator<Passegger>
    {
        public PasseggerValidator() {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Name).Length(3, 10);
            RuleFor(x=>x.Cognome).NotEmpty().NotNull(); 
            RuleFor(x=> x.Cognome).Length(3,15);
            RuleFor(x => x.TypeTicket).IsEnumName(typeof(TycketClass));
            RuleForEach(x => x.Luggages).Must(w => w.Peso > 0);
            RuleFor(x => x.Etá).GreaterThan(0);
        }

    }
}
