//PROJECT NAME: Data
//CLASS NAME: GetTPlans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetTPlans : IGetTPlans
	{
		readonly IApplicationDB appDB;
		
		public GetTPlans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string tplans) GetTPlansSp(
			string de_code,
			string tplans)
		{
			DeCodeType _de_code = de_code;
			Infobar _tplans = tplans;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTPlansSp";
				
				appDB.AddCommandParameter(cmd, "de_code", _de_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tplans", _tplans, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				tplans = _tplans;
				
				return (Severity, tplans);
			}
		}
	}
}
