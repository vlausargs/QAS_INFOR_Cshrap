//PROJECT NAME: Logistics
//CLASS NAME: CheckPoStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckPoStatus : ICheckPoStatus
	{
		readonly IApplicationDB appDB;
		
		
		public CheckPoStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PoNumAndStatList,
		string Infobar) CheckPoStatusSp(string PoType,
		string PoNumListToCheck,
		string PoNumAndStatList,
		string Infobar)
		{
			PoTypeType _PoType = PoType;
			LongListType _PoNumListToCheck = PoNumListToCheck;
			LongListType _PoNumAndStatList = PoNumAndStatList;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckPoStatusSp";
				
				appDB.AddCommandParameter(cmd, "PoType", _PoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNumListToCheck", _PoNumListToCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNumAndStatList", _PoNumAndStatList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoNumAndStatList = _PoNumAndStatList;
				Infobar = _Infobar;
				
				return (Severity, PoNumAndStatList, Infobar);
			}
		}
	}
}
