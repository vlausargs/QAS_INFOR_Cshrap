//PROJECT NAME: Material
//CLASS NAME: TrnitemRefNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TrnitemRefNumValid : ITrnitemRefNumValid
	{
		readonly IApplicationDB appDB;
		
		
		public TrnitemRefNumValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RefNum,
		string Infobar) TrnitemRefNumValidSp(string RefType,
		string RefNum,
		string Infobar)
		{
			RefTypeIJPRType _RefType = RefType;
			JobPoReqNumType _RefNum = RefNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrnitemRefNumValidSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefNum = _RefNum;
				Infobar = _Infobar;
				
				return (Severity, RefNum, Infobar);
			}
		}
	}
}
