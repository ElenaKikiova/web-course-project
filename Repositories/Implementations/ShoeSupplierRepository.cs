﻿using CourseProject.Models;
using CourseProject.Repositories;
using CourseProject.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Services.Implementations
{
    public class ShoeSupplierRepository : IShoeSupplierRepository
    {
        private readonly NoFakeShoesDbContext noFakeShoesDbContext;

        private readonly DbSet<ShoeSupplier> shoeSuppliersDbSet;

        public ShoeSupplierRepository(NoFakeShoesDbContext noFakeShoesDbContext)
        {
            this.noFakeShoesDbContext = noFakeShoesDbContext;
            shoeSuppliersDbSet = noFakeShoesDbContext.Set<ShoeSupplier>();
        }

        public List<ShoeSupplier> GetAll()
        {
            var joinQuery = noFakeShoesDbContext.Suppliers.Include(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers).ThenInclude(shoe_ShoeSuppliers => shoe_ShoeSuppliers.Shoe);
            return joinQuery.ToList();
        }

        public ShoeSupplier GetById(int id)
        {
            return shoeSuppliersDbSet.Find(id);
        }

        public void Insert(ShoeSupplier shoeSupplier)
        {
            shoeSuppliersDbSet.Add(shoeSupplier);
            noFakeShoesDbContext.SaveChanges();
        }

        public void Update(ShoeSupplier shoeSupplier)
        {
            ShoeSupplier shoeSupplierInDB = GetById(shoeSupplier.Id);

            if(shoeSupplierInDB != null)
            {
                noFakeShoesDbContext.Entry(shoeSupplierInDB).State = EntityState.Detached;
            }
            noFakeShoesDbContext.Entry(shoeSupplierInDB).State = EntityState.Modified;
            noFakeShoesDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            shoeSuppliersDbSet.Remove(GetById(id));
            noFakeShoesDbContext.SaveChanges();
        }
    }
}
