using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReadFile
    {
        public static List<Infracao> GetData(string path)
        {
            StreamReader reader = new StreamReader(path);
            string jsonString = reader.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<Radar>(jsonString);

            if (lst != null) return lst.Infracoes;
            return null;

        }
    }
}
