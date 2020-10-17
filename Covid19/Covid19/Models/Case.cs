using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19
{
    public class Case
    {
        [JsonProperty("NISS")]
        public string Niss { get; set; }
        [JsonProperty("DATE")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Date { get; set; }
        [JsonProperty("TX_DESCR_NL")]
        public string Town_NL { get; set; }
        [JsonProperty("TX_DESCR_FR")]
        public string Town_FR { get; set; }
        [JsonProperty("TX_ADM_DSTR_DESCR_NL")]
        public string Arrondissement_NL { get; set; }
        [JsonProperty("TX_ADM_DSTR_DESCR_FR")]
        public string Arrondissement_FR { get; set; }
        [JsonProperty("PROVINCE")]
        public string Province { get; set; }
        [JsonProperty("REGION")]
        public string Region { get; set; }
        [JsonProperty("CASES")]
        public string Cases { get; set; }
    }
}
