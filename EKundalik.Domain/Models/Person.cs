﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKundalik.Domain.Models
{
    public abstract class Person 
    {
        public required string FullName { get; set; }
        public DateTime BirthDate { get; set; } 
        public bool Gender { get; set; } = true;
    }
}
