using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class KontaktiController : ControllerBase
    {
        private readonly PharmacyDbContext _kontaktiDbContext;

        public KontaktiController(PharmacyDbContext kontaktiDbContext)
        {
            _kontaktiDbContext = kontaktiDbContext;
        }

        [HttpGet]
        [Route("GetKontakti")]
        public async Task<IEnumerable<Kontakti>> GetKontakts()
        {
            return await _kontaktiDbContext.Kontakti.ToListAsync();
        }
        [HttpPost]
        [Route("AddKontakti")]
        public async Task<Kontakti> AddKontakti(Kontakti objKontakti)
        {
            _kontaktiDbContext.Kontakti.Add(objKontakti);
            await _kontaktiDbContext.SaveChangesAsync();
            return objKontakti;
        }
        [HttpPatch]
        [Route("UpdateKontakti/{id}")]
        public async Task<Kontakti> UpdateKontakti(Kontakti objKontakti)
        {
            _kontaktiDbContext.Entry(objKontakti).State = EntityState.Modified;
            await _kontaktiDbContext.SaveChangesAsync();
            return objKontakti;
        }

        [HttpDelete]
        [Route("DeleteKontakti/{id}")]

        public bool DeleteKontakti(int id)
        {
            bool a = false;
            var kontakti = _kontaktiDbContext.Kontakti.Find(id);

            if (kontakti != null)
            {
                a = true;
                _kontaktiDbContext.Entry(kontakti).State = EntityState.Deleted;
                _kontaktiDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }
    }
}
       

