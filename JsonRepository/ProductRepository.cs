using Domain.Entities;
using Domain.Ports.Secondary;
using System.Text.Json;

namespace JsonRepository
{
    public class ProductRepository:IRepository
    {
        private readonly string _path;

        public ProductRepository(string path)
        {
            _path = path;
        }

        public void Save(Product product)
        {
            var products = GetAll();
            products.Add(product);
            
            var options = new JsonSerializerOptions{ WriteIndented = true };
            string json = JsonSerializer.Serialize(products, options);

            File.WriteAllText(_path, json);
        }

        public List<Product> GetAll()
        {
            if (!File.Exists(_path))
            {
                return new List<Product>();
            }
            string json = File.ReadAllText(_path);
            var products = JsonSerializer.Deserialize<List<Product>>(json);
            return products ?? new List<Product>();
        }
    }
}
