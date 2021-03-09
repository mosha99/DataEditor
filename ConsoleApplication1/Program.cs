using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//using Json;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sonString = File.ReadAllText("~/json1.json",Encoding.UTF8);
            JsonReader reader = new JsonTextReader(new StringReader(sonString));
            var weatherForecast = JsonSerializer.Deserialize<seting>(reader);
        }
    }
}
