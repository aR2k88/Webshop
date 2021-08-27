namespace Webshop.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Number { get; set; }

        public CartItem(Product product, int number)
        {
            Product = product;
            Number = number;
        }
    }
}