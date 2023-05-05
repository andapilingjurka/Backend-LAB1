using E_PharmacyCrud.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_PharmacyCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StafiController : ControllerBase
    {
        private readonly PharmacyDbContext _stafiDbContext;

        public StafiController(PharmacyDbContext stafiDbContext)
        {
            _stafiDbContext = stafiDbContext;
        }

      
        [HttpGet]
        [Route("GetStafi")]
        public async Task<IEnumerable<Stafi>> GetStafi()
        {
            return await _stafiDbContext.Stafi.ToListAsync();
        }

        [HttpPost]
        [Route("AddStafi")] 

        public async Task<Stafi>AddStafi(Stafi objStafi)
        {
            _stafiDbContext.Stafi.Add(objStafi);
            await _stafiDbContext.SaveChangesAsync();
            return objStafi;

        }

        [HttpPatch]
        [Route("UpdateStafi/{id}")]
        public async Task<Stafi> UpdateStafi(Stafi objStafi)
        {
            _stafiDbContext.Entry(objStafi).State = EntityState.Modified;
            await _stafiDbContext.SaveChangesAsync();
            return objStafi;
        }
        [HttpDelete]
        [Route("DeleteStafi/{id}")]
        public bool DeleteStafi(int id)
        {
            bool a = false;
            var stafi=_stafiDbContext.Stafi.Find(id);
            if (stafi != null)
            {
                a = true;
                _stafiDbContext.Entry(stafi).State = EntityState.Deleted;
                _stafiDbContext.SaveChanges();  
            }
            else
            {
                a = false;
            }
            return a;
        }

    }
}
