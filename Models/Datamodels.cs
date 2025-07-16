namespace MySaaSApp.Models
{
    public class OrderItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class InvoiceRequest
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
