//PROJECT NAME: Logistics
//CLASS NAME: SetPoStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class SetPoStatus : ISetPoStatus
	{
		readonly IApplicationDB appDB;
		
		
		public SetPoStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SetPoStatusSp(string PoNumList,
		string Infobar)
		{
			LongListType _PoNumList = PoNumList;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetPoStatusSp";
				
				appDB.AddCommandParameter(cmd, "PoNumList", _PoNumList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
