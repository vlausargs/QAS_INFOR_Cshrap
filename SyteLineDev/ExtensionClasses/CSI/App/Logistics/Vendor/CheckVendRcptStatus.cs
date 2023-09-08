//PROJECT NAME: Logistics
//CLASS NAME: CheckVendRcptStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckVendRcptStatus : ICheckVendRcptStatus
	{
		readonly IApplicationDB appDB;
		
		
		public CheckVendRcptStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PReceived,
		string Infobar) CheckVendRcptStatusSp(string PoNum,
		int? PReceived,
		int? PWithMessage = 0,
		string Infobar = null)
		{
			PoNumType _PoNum = PoNum;
			ListYesNoType _PReceived = PReceived;
			ListYesNoType _PWithMessage = PWithMessage;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckVendRcptStatusSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReceived", _PReceived, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWithMessage", _PWithMessage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PReceived = _PReceived;
				Infobar = _Infobar;
				
				return (Severity, PReceived, Infobar);
			}
		}
	}
}
