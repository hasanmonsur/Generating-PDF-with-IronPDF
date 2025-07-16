using MySaaSApp.Models;

namespace MySaaSApp.Services
{

    public class PdfInvoiceService
    {
        public void GenerateInvoice(string customerName, string email, List<OrderItem> items)
        {
            // Initialize the PDF renderer
            var renderer = new ChromePdfRenderer();

            // HTML template with dynamic data
            string htmlContent = $@"
                <html>
                    <head><style>body {{ font-family: Arial; }}</style></head>
                    <body>
                        <img src='https://example.com/logo.png' width='150'/>
                        <h1>Invoice</h1>
                        <p>Customer: {customerName}</p>
                        <p>Email: {email}</p>
                        <table border='1'>
                            <tr><th>Item</th><th>Price</th></tr>
                            {string.Join("", items.Select(item => $"<tr><td>{item.Name}</td><td>${item.Price}</td></tr>"))}
                        </table>
                        <p>Total: ${items.Sum(item => item.Price)}</p>
                        <p>Thank you for your business!</p>
                    </body>
                </html>";

            // Generate PDF
            var pdf = renderer.RenderHtmlAsPdf(htmlContent);

            // Save or send via email
            pdf.SaveAs($"Invoices/Invoice_{DateTime.Now:yyyyMMddHHmmss}.pdf");
        }
    }

    

}