//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvPrep.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROInvPrep
	{
		(int? ReturnCode, string Infobar) SSSFSSROInvPrepSp(string SroNum,
		string Action,
		string Value = null,
		string Infobar = null);
	}
	
	public class SSSFSSROInvPrep : ISSSFSSROInvPrep
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInvPrep(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSROInvPrepSp(string SroNum,
		string Action,
		string Value = null,
		string Infobar = null)
		{
			FSSRONumType _SroNum = SroNum;
			StringType _Action = Action;
			FSSROOperStatType _Value = Value;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInvPrepSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
