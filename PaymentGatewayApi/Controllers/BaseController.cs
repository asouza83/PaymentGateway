using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Api.App_Start;

namespace PaymentGateway.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
            UnityConfig.Inicializar();
        }
    }
}