using Microsoft.AspNetCore.Mvc;

namespace HelloWorldOne.Controllers
{
    [Route("[controller]")]
    public class AboutController 
    {
        [Route("[action]")]
        public string Phone()
        {
            return "+10086";
        }
        [Route("[action]")]
        public string Country()
        {
            return "中国";
        }
    }
}