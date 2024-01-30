using CSharp.Web.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

            var stopwatchAny = Stopwatch.StartNew();
            var any_status = numbers.Any(x => x > 0);// slow
            stopwatchAny.Stop();
            
            var stopwatchExists = Stopwatch.StartNew();
            var exists_status = numbers.Exists(x => x > 0);// fast
            stopwatchExists.Stop();

            return Ok(new
            {
                any_execution_time = $"Execution time for 'any_status': {stopwatchAny.ElapsedMilliseconds} ms",
                exists_execution_time = $"Execution time for 'exists_status': {stopwatchExists.ElapsedMilliseconds} ms"
            });
        }

        [HttpGet]
        [Route("minimized-statement-null")]
        public ActionResult MinStatementNull()
        {
            var response = this._productService.MinStatementNull();

            return Ok(response);
        }

        [HttpGet]
        [Route("SpreadOperator")]
        public ActionResult SpreadOperator()
        {
            var response = this._productService.SpreadOperator();

            return Ok(response);
        }
    }
}
