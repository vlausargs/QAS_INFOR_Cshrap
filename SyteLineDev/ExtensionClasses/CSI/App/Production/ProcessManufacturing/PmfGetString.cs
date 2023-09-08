//PROJECT NAME: Production
//CLASS NAME: PmfGetString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetString : IPmfGetString
	{
		readonly IApplicationDB appDB;
		
		public PmfGetString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Result) PmfGetStringSp(
			string StringId,
			string Result = null)
		{
			StringType _StringId = StringId;
			StringType _Result = Result;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetStringSp";
				
				appDB.AddCommandParameter(cmd, "StringId", _StringId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result", _Result, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Result = _Result;
				
				return (Severity, Result);
			}
		}
	}
}
