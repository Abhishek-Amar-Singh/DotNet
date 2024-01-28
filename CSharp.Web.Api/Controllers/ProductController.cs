using CSharp.Web.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        [Route("PatternVA")]
        public ActionResult PatternVA(int n)
        {
            var response = this._productService.PatternVA(n);

            return Ok(response);
        }

        [HttpGet]
        [Route("AreStringEqual")]
        public ActionResult AreStringEqual(string first, string second)
        {
            var res1 = first.ToUpper() == second.ToUpper(); // slow

            var res2 = string.Equals(first, second, StringComparison.OrdinalIgnoreCase); // fast

            return Ok(new
            {
                res1 = res1,
                res2 = res2
            });
        }

        [HttpGet]
        [Route("with-keyword")]
        public ActionResult withKeyword()
        {
            var mario = new Person(Guid.NewGuid(), "Mario", "Mario");

            var lungi = mario with { first_name = "Lungi" };

            return Ok(lungi);
        }

        [HttpGet]
        [Route("ConvertExpandoObjToDict")]
        public ActionResult ConvertExpandoObjToDict()
        {
            dynamic myObj = new ExpandoObject();

            myObj.first_name = "Abhishek";
            myObj.second_name = "Singh";
            myObj.age = 23;

            var dict = new Dictionary<string, object>(myObj);

            return Ok(dict);
        }

        [HttpGet]
        [Route("ProvideJsonUnmappedMemberHandling")]
        public ActionResult ProvideJsonUnmappedMemberHandling()
        {
            // Missing member handling
            var json = """
                {
                "id": 42,
                "name": "Dimple Purohit"
                }
                """;

            var options = new JsonSerializerOptions
            {
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
            };
            var employee = JsonSerializer.Deserialize<Employee>(json, options);

            return Ok(employee);
        }

        [HttpGet]
        [Route("JsonNamingPolicy")]
        public ActionResult P()
        {
            var json = """
                {
                "app_name": "LinkedIn",
                "email_address_registered": "Zarina.Wahab@gmail.com"
                }
                """;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };

            var socialMedia = JsonSerializer.Deserialize<SocialMedia>(json, options);

            return Ok(socialMedia);

        }
    }

    public record Person(Guid id, string first_name, string last_name);

    //--JsonUnmappedMemberHandling
    public class Employee
    {
        public int id { get; set; }
    }

    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class Employee2
    {
        public int id { get; set; }
    }
    //--JsonUnmappedMemberHandling
    //--JsonNamingPolicy
    public record SocialMedia(string AppName, string EmailAddressRegistered);
    //--JsonNamingPolicy
}
