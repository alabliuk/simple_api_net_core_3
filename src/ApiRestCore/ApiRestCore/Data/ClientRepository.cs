using ApiRestCore.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ApiRestCore.Data
{
    public class ClientRepository : Conn
    {
        public List<Client> GetAllClients()
        {
            List<Client> lcli;

            using (IDbConnection con = new SqlConnection(ConnString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lcli = con.Query<Client>("GetAllClients", null, commandType: CommandType.StoredProcedure).ToList();
            }

            return lcli;
        }

        public Client GetClient(int Id)
        {
            Client cli = new Client();

            using (IDbConnection con = new SqlConnection(ConnString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var vParams = new DynamicParameters();
                vParams.Add("@Id", Id);

                cli = con.Query<Client>("GetClient", vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return cli;
        }

        public int Save(Client client)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(ConnString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var vParams = new DynamicParameters();
                vParams.Add("@name", client.Name);
                vParams.Add("@phone", client.Phone);
                vParams.Add("@email", client.Email);
                vParams.Add("@comments", client.Comments);

                rowAffected = con.Query<int>("InsertClient", vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return rowAffected;
        }

        public int Update(Client client)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(ConnString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var vParams = new DynamicParameters();
                vParams.Add("@id", client.Id);
                vParams.Add("@name", client.Name);
                vParams.Add("@phone", client.Phone);
                vParams.Add("@email", client.Email);
                vParams.Add("@comments", client.Comments);

                rowAffected = con.Query<int>("UpdateClient", vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return rowAffected;
        }

        public int Delete(int Id)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(ConnString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var vParams = new DynamicParameters();
                vParams.Add("@id", Id);

                rowAffected = con.Query<int>("DeleteClient", vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return rowAffected;
        }
    }
}
