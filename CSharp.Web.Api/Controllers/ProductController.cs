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

        [HttpGet]
        [Route("FrozenDictCollection")]
        public ActionResult FrozenDictCollection()
        {
            var response = this._productService.FrozenDictCollection();

            return Ok(response);
        }

        [HttpGet]
        [Route("FrozenSetCollection")]
        public ActionResult FrozenSetCollection()
        {
            var response = this._productService.FrozenSetCollection();

            return Ok(response);
        }

        [HttpGet]
        [Route("JsonNodeExample")]
        public ActionResult JsonNodeExample()
        {
            var response = this._productService.JsonNodeExample();

            return Ok(response);
        }

        [HttpGet]
        [Route("RelationalPattern")]
        public ActionResult RelationalPattern(decimal score)
        {
            if (score is >= 35 and <= 100)
            {
                return Ok("Passed the exam.");
            }
            else if (score is >=0 and <=34) return Ok("Failed the exam.");
            else return BadRequest("Invalid input.");
        }

        [HttpGet]
        [Route("Any_Exists")]
        public ActionResult Any_Exists()
        {
            List<int> numbers = new List<int>() { 1, 89, -9, 110, 876, 62432, 7, 86, -61};

            var any_status = numbers.Any(x => x > 0);// slow
            var exists_status = numbers.Exists(x => x > 0);// fast

            return Ok(new
            {
                any_status = any_status,
                exists_status = exists_status
            });
        }
    }
}
