﻿using Microsoft.EntityFrameworkCore;
using ProCar.Models;

namespace ProCar.Services
{
    public class BrandService : IBrandService
    {
        private ApplicationDbContext _context;
        public BrandService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Brand AddType(string name)
        {
            Brand brand = new Brand() { Name = name };
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand;
        }

        public void DeleteType(int id)
        {
            var brand = _context.Brands.Find(id);
            _context.Brands.Remove(brand!);
            _context.SaveChanges();
        }

        public void EditType(int id, string name)
        {
            var brand = _context.Brands.Find(id);
            brand!.Name = name;
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }

        public Brand GetById(int id)
        {
            var brand = _context.Brands.Include(a=>a.Cars).ThenInclude(a=>a.GearboxType).FirstOrDefault(a=>a.Id == id);
            return brand!;
        }
        public bool ElementExists(int id)
        {
            return _context.Brands.Find(id) != null;
        }

        public List<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }

        public int ElementExists(string name)
        {
            var brand = _context.Brands.FirstOrDefault(item => item.Name == name);
            if (brand == null)
                return 0;
            return brand.Id;
        }

    }
}
