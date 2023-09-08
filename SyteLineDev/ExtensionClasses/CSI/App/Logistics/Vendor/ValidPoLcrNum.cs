//PROJECT NAME: CSIVendor
//CLASS NAME: ValidPoLcrNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IValidPoLcrNum
	{
		int ValidPoLcrNumSp(string PLcrNum,
		                    string PVendNum,
		                    string PPoNum,
		                    string PStat,
		                    ref string Infobar);
	}
	
	public class ValidPoLcrNum : IValidPoLcrNum
	{
		readonly IApplicationDB appDB;
		
		public ValidPoLcrNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidPoLcrNumSp(string PLcrNum,
		                           string PVendNum,
		                           string PPoNum,
		                           string PStat,
		                           ref string Infobar)
		{
			VendLcrNumType _PLcrNum = PLcrNum;
			VendNumType _PVendNum = PVendNum;
			PoNumType _PPoNum = PPoNum;
			PoStatType _PStat = PStat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidPoLcrNumSp";
				
				appDB.AddCommandParameter(cmd, "PLcrNum", _PLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
