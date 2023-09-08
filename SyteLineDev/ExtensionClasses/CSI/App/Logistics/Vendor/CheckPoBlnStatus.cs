//PROJECT NAME: CSIVendor
//CLASS NAME: CheckPoBlnStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckPoBlnStatus
	{
		int CheckPoBlnStatusSp(string PoNumAndPoLineListToCheck,
		                       ref string PoNumAndPoLineAndStatList,
		                       ref string Infobar);
	}
	
	public class CheckPoBlnStatus : ICheckPoBlnStatus
	{
		readonly IApplicationDB appDB;
		
		public CheckPoBlnStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckPoBlnStatusSp(string PoNumAndPoLineListToCheck,
		                              ref string PoNumAndPoLineAndStatList,
		                              ref string Infobar)
		{
			LongListType _PoNumAndPoLineListToCheck = PoNumAndPoLineListToCheck;
			LongListType _PoNumAndPoLineAndStatList = PoNumAndPoLineAndStatList;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckPoBlnStatusSp";
				
				appDB.AddCommandParameter(cmd, "PoNumAndPoLineListToCheck", _PoNumAndPoLineListToCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNumAndPoLineAndStatList", _PoNumAndPoLineAndStatList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoNumAndPoLineAndStatList = _PoNumAndPoLineAndStatList;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
