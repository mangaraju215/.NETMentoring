namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product other
                && Name == other.Name
                && Price.Equals(other.Price);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Name, Price);
        }
    }
}
