//PROJECT NAME: Production
//CLASS NAME: SetMethod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class SetMethod : ISetMethod
	{
		readonly IApplicationDB appDB;
		
		
		public SetMethod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SetMethodSp(string MethodValInput)
		{
			StringType _MethodValInput = MethodValInput;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetMethodSp";
				
				appDB.AddCommandParameter(cmd, "MethodValInput", _MethodValInput, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
