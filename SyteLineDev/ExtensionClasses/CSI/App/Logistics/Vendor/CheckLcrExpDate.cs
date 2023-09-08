//PROJECT NAME: CSIVendor
//CLASS NAME: CheckLcrExpDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckLcrExpDate
	{
		int CheckLcrExpDateSp(string PoNum,
		                      DateTime? DueDate,
		                      ref string Infobar);
	}
	
	public class CheckLcrExpDate : ICheckLcrExpDate
	{
		readonly IApplicationDB appDB;
		
		public CheckLcrExpDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckLcrExpDateSp(string PoNum,
		                             DateTime? DueDate,
		                             ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			DateType _DueDate = DueDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckLcrExpDateSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
