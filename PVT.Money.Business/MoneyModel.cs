using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    class MoneyModel
    {
        [JsonProperty("5. Exchange Rate")]
        public decimal Exchange_Rate { get; set; }
    }
}
