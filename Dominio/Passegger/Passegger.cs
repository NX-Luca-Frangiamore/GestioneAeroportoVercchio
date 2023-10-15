﻿using Dominio.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TycketClass { First,Second}
    public class Passegger:Person
    {
    
        public List<Luggage> Luggages { get; set; }
        public int Etá { get; set; }
        public Ticket Ticket { get; set; }

        public bool IsValid()
        {
            var v = new PasseggerValidator().Validate(this);
            return v.IsValid;
        }
    }
}
