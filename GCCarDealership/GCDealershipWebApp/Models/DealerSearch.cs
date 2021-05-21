using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCDealershipWebApp.Models
{
    public class DealerSearch
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public string GetQueryString()
        {
            List<string> qParams = new List<string>();
            string queryString = string.Empty;

            if (!string.IsNullOrEmpty(this.Make))
                qParams.Add($"make={this.Make}");

            if (!string.IsNullOrEmpty(this.Model))
                qParams.Add($"model={this.Model}");

            if (this.Year != 0)
                qParams.Add($"year={this.Year}");

            if (!string.IsNullOrEmpty(this.Color))
                qParams.Add($"color={this.Color}");

            foreach (string param in qParams)
                queryString += queryString.Length <= 0 ? (param) : ("&" + param);

            return queryString;
        }
    }
}
