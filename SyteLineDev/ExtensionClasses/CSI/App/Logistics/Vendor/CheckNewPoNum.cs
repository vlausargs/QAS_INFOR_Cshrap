//PROJECT NAME: CSIVendor
//CLASS NAME: CheckNewPoNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckNewPoNum
	{
		int CheckNewPoNumSp(string PoNum,
		                    ref string Infobar);
	}
	
	public class CheckNewPoNum : ICheckNewPoNum
	{
		readonly IApplicationDB appDB;
		
		public CheckNewPoNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckNewPoNumSp(string PoNum,
		                           ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckNewPoNumSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
