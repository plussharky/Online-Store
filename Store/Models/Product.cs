namespace Store.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return String.Format("ProductID: {0},\nName: {1},\nDescription: {2},\nPrice: {3},\nCategoy: {4}", ProductID, Name, Description, Price, Category);
        }
    }
}
