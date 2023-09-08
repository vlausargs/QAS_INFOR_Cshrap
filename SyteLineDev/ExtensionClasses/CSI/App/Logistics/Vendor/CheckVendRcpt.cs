//PROJECT NAME: CSIVendor
//CLASS NAME: CheckVendRcpt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckVendRcpt
	{
		int CheckVendRcptSp(string PoNum,
		                    ref string Infobar);
	}
	
	public class CheckVendRcpt : ICheckVendRcpt
	{
		readonly IApplicationDB appDB;
		
		public CheckVendRcpt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckVendRcptSp(string PoNum,
		                           ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckVendRcptSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
