//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROOperUpdateStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROOperUpdateStatus
	{
		(int? ReturnCode, string Infobar) SSSFSSROOperUpdateStatusSp(string SRONum,
		string Infobar);
	}
	
	public class SSSFSSROOperUpdateStatus : ISSSFSSROOperUpdateStatus
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROOperUpdateStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSROOperUpdateStatusSp(string SRONum,
		string Infobar)
		{
			FSSRONumType _SRONum = SRONum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROOperUpdateStatusSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
