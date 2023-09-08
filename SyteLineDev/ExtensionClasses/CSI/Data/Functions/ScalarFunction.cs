using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using CSI.Data.Utilities;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CSI.Data.Functions
{
    public class ScalarFunction : IScalarFunction
    {
        readonly IApplicationDB appDB;
        readonly IQueryLanguage queryLanguage;

        public ScalarFunction(IApplicationDB appDB, IQueryLanguage queryLanguage)
        {
            this.appDB = appDB;
            this.queryLanguage = queryLanguage;
        }

        public T Execute<T>(string function, params object[] functionParameters)
        {
            if (function.Contains("(") && function.Contains(")"))
                throw new ArgumentException("Error: [function] should not contain parameters.\r\n" +
                    "Parameters should be passed as params object[] functionParameters.");

            var parameterList = new List<string>();

            int pindex = 0;
            foreach (var parameter in functionParameters)
            {
                parameterList.Add($"{{{pindex++}}}");
            }

            string functionExpression = string.Empty;
            if (function.Trim().StartsWith("@") && functionParameters.Length == 0)
            {
                functionExpression = $"SELECT {function}";
            }
            else
            {
                functionExpression = $"SELECT {function}({string.Join(",", parameterList)})";
            }
            var parameterized = queryLanguage.WhereClause(functionExpression, functionParameters);

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = parameterized.Statement;

                foreach (var parameter in parameterized.Parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                object retValue = this.appDB.ExecuteScalar<T>(cmd);
                return (retValue == DBNull.Value) ? default(T) : (T)retValue;
           }
        }
    }
}
