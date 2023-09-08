//PROJECT NAME: CSIVendor
//CLASS NAME: CheckPOLineStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckPOLineStatus
	{
		int CheckPOLineStatusSp(string PoNum,
		                        ref byte? ReturnFlag,
		                        ref string Infobar);
	}
	
	public class CheckPOLineStatus : ICheckPOLineStatus
	{
		readonly IApplicationDB appDB;
		
		public CheckPOLineStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckPOLineStatusSp(string PoNum,
		                               ref byte? ReturnFlag,
		                               ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			ListYesNoType _ReturnFlag = ReturnFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckPOLineStatusSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnFlag", _ReturnFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReturnFlag = _ReturnFlag;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
