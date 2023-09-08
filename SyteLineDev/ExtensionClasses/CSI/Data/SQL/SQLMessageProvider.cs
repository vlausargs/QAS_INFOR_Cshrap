using CSI.MG;
using System.Data;
using System.Data.SqlClient;

namespace CSI.Data.SQL
{
    public class SQLMessageProvider : IMessageProvider
    {
        readonly IDbConnection connection;
        readonly IDbTransaction transaction;

        public SQLMessageProvider(IDbConnection connection, IDbTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public string AppendMessage(string message, string messageID)
        {
            string Infobar = string.Empty;

            using (IDbCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MsgAppSp";

                cmd.Parameters.Add(new SqlParameter("BaseMsg", messageID));
                var p = new SqlParameter("Infobar", SqlDbType.NVarChar);
                p.Direction = ParameterDirection.InputOutput;
                p.Size = 1024;
                p.Value = message;
                cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();

                Infobar = ((SqlCommand)cmd).Parameters["Infobar"].Value.ToString();

                return Infobar;
            }
        }

        public string AppendMessage(string message, string messageID, params object[] args)
        {
            string Infobar = string.Empty;

            using (IDbCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MsgAppSp";

                cmd.Parameters.Add(new SqlParameter("BaseMsg", messageID));

                for (int i = 0; i < args.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter($"Parm{i + 1}", args[i]));
                }

                var p = new SqlParameter("Infobar", SqlDbType.NVarChar);
                p.Direction = ParameterDirection.InputOutput;
                p.Size = 1024;
                p.Value = message;
                cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();

                Infobar = ((SqlCommand)cmd).Parameters["Infobar"].Value.ToString();

                return Infobar;
            }
        }

        public string GetMessage(string messageId)
        {
            string Infobar = string.Empty;

            using (IDbCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MsgAppSp";

                cmd.Parameters.Add(new SqlParameter("BaseMsg", messageId));
                var p = new SqlParameter("Infobar", SqlDbType.NVarChar);
                p.Direction = ParameterDirection.Output;
                p.Size = 1024;
                cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();

                Infobar = ((SqlCommand)cmd).Parameters["Infobar"].Value.ToString();
                return Infobar;
            }
        }

        public string GetMessage(string messageId, params object[] args)
        {
            string Infobar = string.Empty;

            using (IDbCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MsgAppSp";

                cmd.Parameters.Add(new SqlParameter("BaseMsg", messageId));

                for (int i = 0; i < args.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter($"Parm{i + 1}", args[i]));
                }

                var p = new SqlParameter("Infobar", SqlDbType.NVarChar);
                p.Direction = ParameterDirection.Output;
                p.Size = 1024;
                cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();

                Infobar = ((SqlCommand)cmd).Parameters["Infobar"].Value.ToString();

                return Infobar;
            }
        }
    }
}