﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal: IProductDal
    {
        private List<Product> _products;


        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ProductId = 1,CategoryId = 1,ProductName = "Bardak",UnitPrice = 15,UnitInStock = 15},
                new Product{ProductId = 2,CategoryId = 2,ProductName = "Kamera",UnitPrice = 500,UnitInStock = 3},
                new Product{ProductId = 3,CategoryId = 3,ProductName = "Telefon",UnitPrice = 1500,UnitInStock = 2},
                new Product{ProductId = 4,CategoryId = 3,ProductName = "Klavye",UnitPrice = 150,UnitInStock = 65},
                new Product{ProductId = 5,CategoryId = 3,ProductName = "Mouse",UnitPrice = 85,UnitInStock = 1}
            };

        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.UnitInStock = product.UnitInStock;
            }
        }

        public void Delete(Product product)
        {
            Product productToDelete= _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            /*foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }*/ //buradaki işlemi linq sorgusuyla 53. satırda yapalım

            // productToDelete = _products.Find(p=>p.ProductId==product.ProductId);  dene

            _products.Remove(productToDelete);

        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }
    }
}