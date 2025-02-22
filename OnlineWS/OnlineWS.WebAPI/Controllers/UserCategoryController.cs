using Microsoft.AspNetCore.Mvc;
using OnlineWS.Business.Contracts;

namespace OnlineWS.WebAPI.Controllers
{
    [Route("api/userCategory")]
    [ApiController]
    public class UserCategoryController : ControllerBase
    {
        private readonly IUserCategoryManager _usrCatMngr;
        public UserCategoryController(IUserCategoryManager usrCatMngr)
        {
            _usrCatMngr = usrCatMngr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryList=await _usrCatMngr.GetAllCategories();
            return Ok(categoryList);
        }
    }
}
