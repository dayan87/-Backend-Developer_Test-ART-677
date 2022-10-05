using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class Estimates
    {
        [Key]
        public int State { get; set; }
        public int Districts { get; set; }
        public decimal EstimatesPopulation { get; set; }
        public decimal EstimatesHouseholds { get; set; }
    }
}

