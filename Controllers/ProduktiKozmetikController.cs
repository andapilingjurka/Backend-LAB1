using E_PharmacyCrud.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktiKozmetikController : ControllerBase
    {
        private readonly PharmacyDbContext _pharmacyDbContext;

        public ProduktiKozmetikController(PharmacyDbContext pharmacyDbContext)
        {   
            _pharmacyDbContext = pharmacyDbContext;
        }


        [HttpGet]
        [Route("GetProduktiKozmetik")]
        public async Task<IEnumerable<ProduktKozmetik>> GetProduktiKozmetik()
        {
            return await _pharmacyDbContext.ProduktKozmetik.ToListAsync();
        }

        [HttpPost]
        [Route("AddProduktiKozmetik")]

        public async Task<ProduktKozmetik> AddProduktiKozmetik(ProduktKozmetik objProduktiKozmetik)
        {
            _pharmacyDbContext.ProduktKozmetik.Add(objProduktiKozmetik);
            await _pharmacyDbContext.SaveChangesAsync();
            return objProduktiKozmetik;

        }

        [HttpPatch]
        [Route("UpdateProduktiKozmetik/{id}")]
        public async Task<ProduktKozmetik> UpdateProduktiKozmetik(ProduktKozmetik objProduktiKozmetik)
        {
            _pharmacyDbContext.Entry(objProduktiKozmetik).State = EntityState.Modified;
            await _pharmacyDbContext.SaveChangesAsync();
            return objProduktiKozmetik;
        }
        [HttpDelete]
        [Route("DeleteProduktiKozmetik/{id}")]
        public bool DeleteProduktiKozmetik(int id)
        {
            bool a = false;
            var produktikozmetik = _pharmacyDbContext.ProduktKozmetik.Find(id);
            if (produktikozmetik != null)
            {
                a = true;
                _pharmacyDbContext.Entry(produktikozmetik).State = EntityState.Deleted;
                _pharmacyDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }

    }
}
