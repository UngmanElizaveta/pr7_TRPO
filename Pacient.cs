using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_7_ungman
{
    public class Pacient
    {
        public string? Name { get; set; }
        public string? LastName { get;set; }
        public string? MiddleName { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? LastAppointment { get; set; }
        public int? LastDoctor { get; set; }
        public string? Diagnosis { get; set; }
        public string? Recomendations { get; set; }
    }
}
