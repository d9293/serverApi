using Oracle.ManagedDataAccess.Client;
using ServerApi.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ServerApi.Controllers
{
    public class BaseController : ApiController
    {
        #region Get state
        public List<CompendiumModel> GetStatesInfo()
        {
            List<CompendiumModel> result = new List<CompendiumModel>();
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["cardcolv"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand() { Connection = con };
                OracleDataReader reader;

                cmd.CommandText = "SELECT * FROM cardcolv.state_program_list";

                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new CompendiumModel()
                        {
                            ID = int.Parse(reader["STATE_ID"].ToString()),
                            Name = reader["STATE_NAME"].ToString()
                        });
                    }
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }
            }
            return result;
        }
        #endregion

        #region Set state
        public HttpResponseMessage SetStateInfo(CompendiumModel model)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["cardcolv"].ConnectionString))
                {
                    OracleCommand cmd = new OracleCommand() { Connection = con };

                    cmd.CommandText = "UPDATE cardcolv.state_program_list SET STATE_NAME = '" + model.Name + "' WHERE STATE_ID = " + model.ID;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        throw new System.Exception(ex.Message);
                    }
                }
            }
            catch (System.Exception ex)
            {
                result = new HttpResponseMessage()
                {
                    Content = new StringContent("status: failed", Encoding.UTF8, "application/json")
                };
            }
            return result;
        }
        #endregion

        #region Create state
        public HttpResponseMessage CreateStateInfo(CompendiumModel model)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["cardcolv"].ConnectionString))
                {
                    OracleCommand cmd = new OracleCommand() { Connection = con };
                    cmd.CommandText = "INSERT INTO cardcolv.state_program_list (STATE_ID, STATE_NAME) VALUES (" + model.ID + ",'" + model.Name + "')";

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        throw new System.Exception(ex.Message);
                    }
                }
            }
            catch (System.Exception ex)
            {
                result = new HttpResponseMessage()
                {
                    Content = new StringContent("status: " + ex.ToString(), Encoding.UTF8, "application/json")
                };
            }
            return result;
        }
        #endregion

        #region Delete state
        public HttpResponseMessage DeleteStateInfo(string id)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["cardcolv"].ConnectionString))
                {
                    OracleCommand cmd = new OracleCommand() { Connection = con };
                    cmd.CommandText = "DELETE FROM cardcolv.state_program_list WHERE STATE_ID = " + id;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        throw new System.Exception(ex.Message);
                    }
                }
            }
            catch (System.Exception ex)
            {
                result = new HttpResponseMessage()
                {
                    Content = new StringContent("status: " + ex.ToString(), Encoding.UTF8, "application/json")
                };
            }
            return result;
        }
        #endregion
    }
}
