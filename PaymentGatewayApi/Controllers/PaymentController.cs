using Microsoft.AspNetCore.Mvc;
using PaymentGateway.DataContracts.Dto;
using PaymentGateway.Interfaces;
using PaymentGateway.Unity;
using System.Collections.Generic;

namespace PaymentGateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        public PaymentController()
            : base()
        {
            _paymentService = AbstractUnityConfig.Resolve<IPaymentService>();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Welcome to ", "Payment Gateway" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PaymentRequest pPaymentRequest)
        {
            _paymentService.Payment(pPaymentRequest);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
