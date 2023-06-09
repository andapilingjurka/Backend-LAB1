
using E_PharmacyCrud.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;

namespace Another_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly PharmacyDbContext _productDbContext;

        public ProductController(PharmacyDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        //[HttpGet]
        //[Route("GetProduct")]
        //public async Task<IEnumerable<Product>> GetProducts()
        //{
        //    // get all products from the context
        //    var products = await _productDbContext.Products.ToListAsync();

        //    // loop through each product and modify its Name property
        //    foreach (var product in products)
        //    {
        //        product.Name += "test";
        //    }

        //    // save changes to the database
        //    await _productDbContext.SaveChangesAsync();

        //    // return all products, including the modified ones
        //    return products;
        //}

        [HttpGet]
        [Route("GetProduct")]

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productDbContext.Products.ToListAsync();
        }

        [HttpPost]
        [Route("addProduct")]

        public async Task<Product> AddProduct(Product objProduct/*, IFormFile photo*/)
        {
            //if (photo != null && photo.Length > 0)
            //{
            //    using (var stream = new MemoryStream())
            //    {
            //        await photo.CopyToAsync(stream);
            //        objProduct.ImgUrl = stream.ToArray();
            //    }
            //}
            _productDbContext.Products.Add(objProduct);
            await _productDbContext.SaveChangesAsync();
            return objProduct;
        }
        [HttpPatch]
        [Route("UpdateProduct/{id}")]

        public async Task<Product> UpdateProduct(Product objProduct)
        {
            _productDbContext.Entry(objProduct).State = EntityState.Modified;
            await _productDbContext.SaveChangesAsync();
            return objProduct;
        }


        [HttpDelete]
        [Route("DeleteProduct/{id}")]

        public bool DeleteProduct(int id)
        {
            bool a = false;
            var product = _productDbContext.Products.Find(id);
            if (product != null)
            {
                a = true;
                _productDbContext.Entry(product).State = EntityState.Deleted;
                _productDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }

            return a;
        }

    }
}
