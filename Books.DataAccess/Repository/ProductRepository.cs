using Books.DataAccess.Data;
using Books.DataAccess.Repository.IRepository;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objfromDb = _db.Products.FirstOrDefault(p => p.Id == obj.Id);
             if(objfromDb != null)
            {
                objfromDb.Title = obj.Title;
                objfromDb.ISBN = obj.ISBN;
                objfromDb.Price = obj.Price;
                objfromDb.ListPrice = obj.ListPrice;
                objfromDb.Price50 = obj.Price50;
                objfromDb.Price100 = obj.Price100;
                objfromDb.Description = obj.Description;
                objfromDb.CategoryId = obj.CategoryId;
                objfromDb.Author = obj.Author;
                if(obj.ImageUrl != null)
                {
                    objfromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
