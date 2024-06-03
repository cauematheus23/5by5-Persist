using Newtonsoft.Json;

namespace Model
{
    public class Infracao
    {
        [JsonProperty("concessionaria")]
        public string Concessionaria { get; set; }
        [JsonProperty("ano_do_pnv_snv")]
        public string AnoPnvSnv { get; set; }
        [JsonProperty("tipo_de_radar")]
        public string TipoRadar { get; set; }
        [JsonProperty("rodovia")]
        public string Rodovia { get; set; }
        [JsonProperty("uf")]
        public string UF { get; set; }
        [JsonProperty("km_m")]
        public string Km { get; set; }
        [JsonProperty("municipio")]
        public string Municipio { get; set; }
        [JsonProperty("tipo_pista")]
        public string TipoPista { get; set; }
        [JsonProperty("sentido")]
        public string Sentido { get; set; }
        [JsonProperty("situacao")]
        public string Situacao { get; set; }
        [JsonProperty("data_da_inativacao")]
        public string[] DataInativacao { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("velocidade_leve")]
        public string Velocidade { get; set; }

        public Infracao()
        {

        }
        public Infracao(string concessionaria, string anoPnvSnv, string tipoRadar, string rodovia, string uF, string km, string municipio, string tipoPista, string sentido, string situacao, string[] dataInativacao, string latitude, string longitude, string velocidade)
        {
            Concessionaria = concessionaria;
            AnoPnvSnv = anoPnvSnv;
            TipoRadar = tipoRadar;
            Rodovia = rodovia;
            UF = uF;
            Km = km;
            Municipio = municipio;
            TipoPista = tipoPista;
            Sentido = sentido;
            Situacao = situacao;
            DataInativacao = dataInativacao;
            Latitude = latitude;
            Longitude = longitude;
            Velocidade = velocidade;
        }
        public override string? ToString() =>
       $"Concessionaria: {Concessionaria}\n" +
       $"AnoPnvSnv: {AnoPnvSnv}\n" +
       $"TipoRadar: {TipoRadar}\n" +
       $"Rodovia: {Rodovia}\n" +
       $"UF: {UF}\n" +
       $"Km: {Km}\n" +
       $"Municipio: {Municipio}\n" +
       $"TipoPista: {TipoPista}\n" +
       $"Sentido: {Sentido}\n" +
       $"Situacao: {Situacao}\n" +
       $"DataInativacao: {string.Join(", ", DataInativacao)}\n" +
       $"Latitude: {Latitude}\n" +
       $"Longitude: {Longitude}\n" +
       $"Velocidade: {Velocidade}";
    }
}