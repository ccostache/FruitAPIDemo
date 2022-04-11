using System;
using System.Collections.Generic;
using System.Text;

namespace FuitApi.Common.Configuration
{
    /// <summary>
    /// Gets the url addresses of the outbound services
    /// </summary>
    public class UrlSettings
    {
        public string FruitInfoUrl { get; set; }
        public string FruitNutritionUrl { get; set; }
    }
}
