namespace Laborotorna9.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    
        public ProductModel(int ID, string Name, int Price) {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
        }

        public override string ToString()
        {
            return $"{this.ID} - {this.Name} - {this.Price}";
        }
    }
}
