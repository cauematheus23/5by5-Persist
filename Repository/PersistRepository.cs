using Microsoft.Data.SqlClient;
using Model;
using System.Data;

namespace Repository
{
    public class PersistRepository
    {
        
        public PersistRepository()
        {
            
        }

        public bool Insert(List<Infracao> infracoes)
        {
            DataBaseSql sql = DataBaseSql.Instance;
            var conn = sql.GetConnection();
            bool result = false;

            //Garantindo que ou passe tudo, ou nada
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    foreach (var infracao in infracoes)
                    {
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO RadarInfo (concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve) " +
                            "VALUES (@conc, @anopnv, @tradar, @rod, @uf, @km, @municipio, @tpista, @sentido, @sit, @data, @lat, @long, @vel)", conn, transaction);

                        cmd.Parameters.Add(new SqlParameter("@conc", SqlDbType.VarChar)).Value = infracao.Concessionaria ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@anopnv", SqlDbType.VarChar)).Value = infracao.AnoPnvSnv ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@tradar", SqlDbType.VarChar)).Value = infracao.TipoRadar ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@rod", SqlDbType.VarChar)).Value = infracao.Rodovia ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@uf", SqlDbType.VarChar)).Value = infracao.UF ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@km", SqlDbType.VarChar)).Value = infracao.Km ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@municipio", SqlDbType.VarChar)).Value = infracao.Municipio ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@tpista", SqlDbType.VarChar)).Value = infracao.TipoPista ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@sentido", SqlDbType.VarChar)).Value = infracao.Sentido ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@sit", SqlDbType.VarChar)).Value = infracao.Situacao ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.VarChar)).Value = infracao.DataInativacao != null ? string.Join(", ", infracao.DataInativacao) : (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@lat", SqlDbType.VarChar)).Value = infracao.Latitude ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@long", SqlDbType.VarChar)).Value = infracao.Longitude ?? (object)DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@vel", SqlDbType.VarChar)).Value = infracao.Velocidade ?? (object)DBNull.Value;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    transaction.Rollback();
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public List<Infracao> GetAll()
        {
            DataBaseSql sql = DataBaseSql.Instance;
            var conn = sql.GetConnection();
            List<Infracao> infracoes = new List<Infracao>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve " +
                       "FROM RadarInfo", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        Infracao infra = new Infracao()
                        {
                            Concessionaria = reader.GetString(0),
                            AnoPnvSnv = reader.GetString(1),
                            TipoRadar = reader.GetString(2),
                            Rodovia = reader.GetString(3),
                            UF = reader.GetString(4),
                            Km = reader.GetString(5),
                            Municipio = reader.GetString(6),
                            TipoPista = reader.GetString(7),
                            Sentido = reader.GetString(8),
                            Situacao = reader.GetString(9),
                            DataInativacao = reader.GetString(10).Split(new[] { ", " }, StringSplitOptions.None),
                            Latitude = reader.GetString(11),
                            Longitude = reader.GetString(12),
                            Velocidade = reader.GetString(13)
                        };


                        infracoes.Add(infra);
                    }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return infracoes;
        }

    }
}