using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPITest.DataAccess.DBContext;
using WebAPITest.Models;
using WebAPITest.Services.Repository;

namespace WebAPITest.Services.Services
{
    public class ActualService : IActualsRepository
    {
        private readonly WebAPITestContext _context;

        public ActualService(WebAPITestContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Actuals>> GetActualById(string id)
        {
             List<Actuals> ActualsObj = new List<Actuals>();

            string[] stateList = id.Split(",");
            foreach (string state in stateList)
            {
                var DbActuals = await _context.Actuals.FindAsync(Convert.ToInt32(state));

                if (DbActuals != null)
                {
                    ActualsObj.Add(new Actuals { State = DbActuals.State, ActualPopulation = DbActuals.ActualPopulation, ActualHouseholds = DbActuals.ActualHouseholds });
                }
                else
                {
                    var DbEstimate = await _context.Estimates.FindAsync(Convert.ToInt32(state));
                    if (DbEstimate != null)
                    {
                     ActualsObj.Add(new Actuals { State = DbEstimate.State, ActualPopulation = DbEstimate.EstimatesPopulation, ActualHouseholds = DbEstimate.EstimatesHouseholds });
                    }
                }
            }
            return ActualsObj.ToArray();  
        }
        public async Task<IEnumerable<Actuals>> GetActuals()
        {
            return await _context.Actuals.ToListAsync();
        }
      
    }
}
