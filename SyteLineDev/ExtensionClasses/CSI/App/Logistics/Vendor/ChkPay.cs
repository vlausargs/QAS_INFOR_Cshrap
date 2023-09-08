//PROJECT NAME: Logistics
//CLASS NAME: ChkPay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ChkPay : IChkPay
	{
		readonly IApplicationDB appDB;
		
		
		public ChkPay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TPayhold,
		string Infobar) ChkPaySp(string VendorVendNum,
		string TPayhold,
		string Infobar)
		{
			VendNumType _VendorVendNum = VendorVendNum;
			WideTextType _TPayhold = TPayhold;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkPaySp";
				
				appDB.AddCommandParameter(cmd, "VendorVendNum", _VendorVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPayhold", _TPayhold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TPayhold = _TPayhold;
				Infobar = _Infobar;
				
				return (Severity, TPayhold, Infobar);
			}
		}
	}
}
