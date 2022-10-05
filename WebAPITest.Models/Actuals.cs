using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class Actuals
    {
        [Key]
        public int State { get; set; }
        public decimal ActualPopulation { get; set; }
        public decimal ActualHouseholds { get; set; }
    }
}

