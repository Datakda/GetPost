using GetPost.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace GetPost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPostController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
           MinMax rnd = new MinMax();

            WebRequest request = WebRequest.Create("https://testgetpost1241414.000webhostapp.com/rnd.txt");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    line = reader.ReadLine();

                    rnd = JsonSerializer.Deserialize<MinMax>(line); ;

                }
            }
            response.Close();
            return $"Min = {rnd.Min}, Max = {rnd.Max}";

        }
    }
}
