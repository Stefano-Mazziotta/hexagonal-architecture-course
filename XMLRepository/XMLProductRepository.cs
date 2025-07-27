using Domain.Entities;
using Domain.Ports.Secondary;
using System.Xml.Linq;

namespace XMLRepository
{
    public class XMLProductRepository : IRepository
    {
        private readonly string _filePath;

        public XMLProductRepository(string filePath = "products.xml")
        {
            _filePath = filePath;

            if(!File.Exists(_filePath) || new FileInfo(_filePath).Length == 0)
            {
                var root = new XElement("Products");
                var doc = new XDocument(root);
                doc.Save(_filePath);
            }
        }

        public List<Product> GetAll()
        {
            var doc = XDocument.Load(_filePath);
            var products = new List<Product>();
            foreach (var element in doc.Descendants("Product"))
            {
                var id = Guid.Parse(element.Element("Id")?.Value ?? Guid.Empty.ToString());
                var name = element.Element("Name")?.Value ?? string.Empty;
                var price = decimal.Parse(element.Element("Price")?.Value ?? "0");
                var product = new Product(id, name, price);
                products.Add(product);
            }

            return products;
        }

        public void Save(Product product)
        {
            var doc = XDocument.Load(_filePath);
            var productElement = new XElement("Product",
                new XElement("Id", product.Id),
                new XElement("Name", product.Name),
                new XElement("Price", product.Price)
            );

            doc.Root?.Add(productElement);
            doc.Save(_filePath);
        }
    }
}
