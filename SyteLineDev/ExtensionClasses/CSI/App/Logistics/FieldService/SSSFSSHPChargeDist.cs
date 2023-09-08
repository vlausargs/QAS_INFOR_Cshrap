//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSHPChargeDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSHPChargeDist : ISSSFSSHPChargeDist
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSHPChargeDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSHPChargeDistSp(
			string SroNum,
			decimal? DistAmt,
			string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			CostPrcType _DistAmt = DistAmt;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSHPChargeDistSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistAmt", _DistAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
