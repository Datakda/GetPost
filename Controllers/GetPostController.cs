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

            WebRequest GETrequest = WebRequest.Create("http://185.195.26.249:8888/RandomDouble");
            WebResponse GETresponse = GETrequest.GetResponse();
            using (Stream stream = GETresponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    line = reader.ReadLine();

                    rnd = JsonSerializer.Deserialize<MinMax>(line); ;

                }
            }
            GETresponse.Close();
            return JsonSerializer.Serialize<MinMax>(rnd);


            WebRequest POSTrequest = WebRequest.Create("URL");
            POSTrequest.Method = "POST";
            string MinAndMax = $"Min={rnd.Min}&Max={rnd.Max}";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(MinAndMax);
            POSTrequest.ContentType = "application/x-www-form-urlencoded";
            POSTrequest.ContentLength = byteArray.Length;

            using (Stream dataStream = POSTrequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

        }
    }
}
