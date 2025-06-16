namespace ObjectOrientedProgramming.Bussiness
{
    public class Beer : Drink, ISalable, ISend
    {
        private const string CATEGORY = "Beer";
        private string Name { get; set; }
        private string Type { get; set; }
        private double AlcoholContent { get; set; }

        public Beer(string name, string type, double alcoholContent, int quantity) : base(quantity)
        {
            Name = name;
            Type = type;
            AlcoholContent = alcoholContent;
        }

        public virtual string GetName()
        {
            return Name;
        }

        public string GetBeerType()
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

        public void SetBeerType(string type)
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

        public decimal GetPrice()
        {
            // Assuming a simple pricing strategy based on alcohol content and quantity
            return (decimal)(AlcoholContent * 0.5 + Quantity * 0.1);
        }

        public void Send(string destinationAddress, string messageContent)
        {
            Console.WriteLine($"Sending {GetName()} to the customer.");
        }
    }
}