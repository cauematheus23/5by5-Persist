using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Radar
    {
        [JsonProperty("radar")]
        public List<Infracao> Infracoes { get; set; }
    }
}
