//PROJECT NAME: CSIVendor
//CLASS NAME: ValidatePoStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IValidatePoStatus
	{
		int ValidatePoStatusSp(string PoNum,
		                       string OldStat,
		                       string NewStat,
		                       ref string Infobar);
	}
	
	public class ValidatePoStatus : IValidatePoStatus
	{
		readonly IApplicationDB appDB;
		
		public ValidatePoStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidatePoStatusSp(string PoNum,
		                              string OldStat,
		                              string NewStat,
		                              ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoStatType _OldStat = OldStat;
			PoStatType _NewStat = NewStat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidatePoStatusSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStat", _OldStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewStat", _NewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
