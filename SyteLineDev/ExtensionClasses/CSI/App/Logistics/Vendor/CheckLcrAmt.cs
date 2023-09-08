//PROJECT NAME: CSIVendor
//CLASS NAME: CheckLcrAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckLcrAmt
	{
		int CheckLcrAmtSp(string PoNum,
		                  ref string Infobar);
	}
	
	public class CheckLcrAmt : ICheckLcrAmt
	{
		readonly IApplicationDB appDB;
		
		public CheckLcrAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckLcrAmtSp(string PoNum,
		                         ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckLcrAmtSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
