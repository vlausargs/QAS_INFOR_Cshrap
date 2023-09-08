//PROJECT NAME: MG.MGCore
//CLASS NAME: SetSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Data.SqlClient;
using CSI.MG.MGCore;

namespace CSI.MG
{
    public class SQLDefineProcessVariable : IDefineProcessVariable
    {
        IDbConnection connection;
        IDbTransaction transaction;

        public SQLDefineProcessVariable(IDbConnection connection, IDbTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        public (int? ReturnCode, string Infobar) DefineProcessVariableSp(string VariableName, string VariableValue, string Infobar)
        {
            using (IDbCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DefineProcessVariableSp";
                cmd.Parameters.Add(new SqlParameter("VariableName", VariableName));
                cmd.Parameters.Add(new SqlParameter("VariableValue", VariableValue));
                var p = new SqlParameter("@Infobar", SqlDbType.NVarChar);
                p.Direction = ParameterDirection.Output;
                p.Size = 1024;
                cmd.Parameters.Add(p);

                var Severity = cmd.ExecuteNonQuery();

                Infobar = p.Value as string;

                return (Severity, Infobar);

            }
        }
    }
}
