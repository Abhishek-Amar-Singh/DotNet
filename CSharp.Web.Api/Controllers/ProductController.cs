using CSharp.Web.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService _productService) =>
            this._productService = _productService;

        [HttpGet]
        [Route("Random_Yield")]
        public ActionResult Random_Yield()
        {
            var response = this._productService.Random_Yield();

            return Ok(response);
        }

        [HttpGet]
        [Route("RandomShuffle")]
        public ActionResult RandomShuffle()
        {
            var response = this._productService.RandomShuffle();

            return Ok(response);
        }
    }
}
