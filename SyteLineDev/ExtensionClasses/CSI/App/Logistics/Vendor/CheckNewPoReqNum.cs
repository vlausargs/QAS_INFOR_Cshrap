//PROJECT NAME: CSIVendor
//CLASS NAME: CheckNewPoReqNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckNewPoReqNum
	{
		int CheckNewPoReqNumSp(string PoReqNum,
		                       ref string Infobar);
	}
	
	public class CheckNewPoReqNum : ICheckNewPoReqNum
	{
		readonly IApplicationDB appDB;
		
		public CheckNewPoReqNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckNewPoReqNumSp(string PoReqNum,
		                              ref string Infobar)
		{
			ReqNumType _PoReqNum = PoReqNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckNewPoReqNumSp";
				
				appDB.AddCommandParameter(cmd, "PoReqNum", _PoReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
