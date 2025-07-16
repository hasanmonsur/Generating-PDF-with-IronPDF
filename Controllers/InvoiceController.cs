using Microsoft.AspNetCore.Mvc;
using MySaaSApp.Models;
using MySaaSApp.Services;

namespace MySaaSApp
{

    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly PdfInvoiceService _pdfService;

        public InvoiceController(PdfInvoiceService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateInvoice([FromBody] InvoiceRequest request)
        {
            _pdfService.GenerateInvoice(request.CustomerName, request.Email, request.Items);
            return Ok("Invoice generated successfully!");
        }
    } 

}