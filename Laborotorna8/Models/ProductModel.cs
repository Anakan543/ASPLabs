namespace Laborotorna8.Models
{
    public class ProductModel
    {
        private int ID;

        private string name;

        private int price;

        private DateTime date = DateTime.Now;

        public ProductModel(int ID, string name, int price) {
        this.ID = ID;
        this.name = name;
        this.price = price;
        }

        public int GetID()
        {
            return ID;
        }

        public string GetName()
        {
            return name;
        }

        public int GetPrice()
        {
            return price;
        }

        public string GetData()
        {
            return date.ToString();
        }
        public override string ToString()
        {
            return $"{ID}.{name} - {price}({date.ToString()})";
        }
    }
}
