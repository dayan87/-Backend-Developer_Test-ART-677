using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Services.Repository
{
    public interface IActualsRepository
    {
        public Task<IEnumerable<Actuals>> GetActuals();
        public Task<IEnumerable<Actuals>> GetActualById(string id);
    }
}
