using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;


namespace CSI.MG.MGCore
{
	public class IsValidVarName : IIsValidVarName
	{
		IApplicationDB appDB;


		public IsValidVarName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

        public int? IsValidVarNameFn(string InputString)
        {
            VeryLongListType _InputString = InputString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[IsValidVarName](@InputString)";

                appDB.AddCommandParameter(cmd, "InputString", _InputString, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<int?>(cmd);

                return Output;
            }
        }
    }
}
