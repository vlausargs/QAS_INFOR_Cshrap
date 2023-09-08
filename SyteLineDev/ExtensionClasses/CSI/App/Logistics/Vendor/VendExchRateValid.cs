//PROJECT NAME: Logistics
//CLASS NAME: VendExchRateValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IVendExchRateValid
	{
		(int? ReturnCode, string Infobar) VendExchRateValidSp(string VendNum,
		string CurrCode,
		decimal? ExchRate,
		string Infobar,
		DateTime? TaxDate = null);
	}
	
	public class VendExchRateValid : IVendExchRateValid
	{
		readonly IApplicationDB appDB;
		
		public VendExchRateValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VendExchRateValidSp(string VendNum,
		string CurrCode,
		decimal? ExchRate,
		string Infobar,
		DateTime? TaxDate = null)
		{
			VendNumType _VendNum = VendNum;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _ExchRate = ExchRate;
			InfobarType _Infobar = Infobar;
			DateType _TaxDate = TaxDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendExchRateValidSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxDate", _TaxDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
