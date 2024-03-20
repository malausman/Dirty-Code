using AttributeRouting.Web.Http;
using DirtyProjectDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using DirtyProjectDemo.Buisness;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Data.OracleClient;
using System.Security.Cryptography;
using System.IO;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;

namespace DirtyProjectDemo.Controllers.API
{

    public class RegistrationApiController 
    {
        string ReturnToken = "";

        [HttpGet]
        [GET("api/SomeEndPoint/getCompleteData/{ID}")]

        public string getCompleteDataFromTable_(HttpRequestMessage request, string ID)
        {
            OracleCommand cmd;
           var config = System.Configuration.ConfigurationManager.ConnectionStrings["Dirty"].ToString();
            using (var conn = new OracleConnection(config))
            {
                using (cmd = conn.CreateCommand())
                {
                    conn.Open();
                    string FULLNAME = "";
                    string completeQueryStmnt = " where id ='" + ID + "'";
                    cmd.CommandText = "select * from users " + completeQueryStmnt;
                   // cmd.Parameters.Add(new OracleParameter("id", id));
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            FULLNAME = reader.IsDBNull((reader.GetOrdinal("FULL_NAME"))) ? "" : reader.GetString(reader.GetOrdinal("FULL_NAME"));

                        }
                        return FULLNAME;
                    }
                    catch (Exception e) { }
                    return null;
                }
            }

        }


       
        
       

     

    }



}
