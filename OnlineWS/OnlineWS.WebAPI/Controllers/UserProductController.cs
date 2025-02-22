using Microsoft.AspNetCore.Mvc;
using OnlineWS.Business.Contracts;

namespace OnlineWS.WebAPI.Controllers
{
    [Route("api/userProduct")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly IUserProductManager _usrPrdMngr;
        public UserProductController(IUserProductManager usrPrdMngr)
        {
            _usrPrdMngr = usrPrdMngr;
        }
        [HttpGet]   
        public async Task<IActionResult> GetAll()
        {
            var productList = await _usrPrdMngr.GetAllProducts();
            return Ok(productList); 
        }
    }
}
