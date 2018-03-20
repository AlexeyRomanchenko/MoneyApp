using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    class CurrencyModelAPI
    {
       
            [JsonProperty("Realtime Currency Exchange Rate")]
            public MoneyModel model { get; set; }
    }
}
