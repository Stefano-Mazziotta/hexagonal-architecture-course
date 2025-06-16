using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming.Bussiness
{
    public class Wine:Drink
    {
        private const string CATEGORY = "Wine";
        private string Name { get; set; }
        private string Type { get; set; }
        private double AlcoholContent { get; set; }
        public Wine(string name, string type, double alcoholContent, int quantity) : base(quantity)
        {
            Name = name;
            Type = type;
            AlcoholContent = alcoholContent;
        }
        public virtual string GetName()
        {
            return Name;
        }
        public string GetWineType()
        {
            return Type;
        }
        public double GetAlcoholContent()
        {
            return AlcoholContent;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetWineType(string type)
        {
            Type = type;
        }
        public void SetAlcoholContent(double alcoholContent)
        {
            AlcoholContent = alcoholContent;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Type: {Type}, Alcohol Content: {AlcoholContent}%");
        }
        public override string GetCategory()
        {
            return CATEGORY;
        }
    }
}
