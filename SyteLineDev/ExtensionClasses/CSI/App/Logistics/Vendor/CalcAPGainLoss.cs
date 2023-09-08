//PROJECT NAME: CSIVendor
//CLASS NAME: CalcAPGainLoss.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICalcAPGainLoss
	{
		int CalcAPGainLossSp(string pVendNum,
		                     int? pVoucher,
		                     string pVendCurrCode,
		                     byte? pUseHistRate,
		                     string pSite,
		                     int? pCheckNum,
		                     ref decimal? rDomGainAmt,
		                     ref string rInfobar);
	}
	
	public class CalcAPGainLoss : ICalcAPGainLoss
	{
		readonly IApplicationDB appDB;
		
		public CalcAPGainLoss(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CalcAPGainLossSp(string pVendNum,
		                            int? pVoucher,
		                            string pVendCurrCode,
		                            byte? pUseHistRate,
		                            string pSite,
		                            int? pCheckNum,
		                            ref decimal? rDomGainAmt,
		                            ref string rInfobar)
		{
			VendNumType _pVendNum = pVendNum;
			VoucherType _pVoucher = pVoucher;
			CurrCodeType _pVendCurrCode = pVendCurrCode;
			ListYesNoType _pUseHistRate = pUseHistRate;
			SiteType _pSite = pSite;
			ApCheckNumType _pCheckNum = pCheckNum;
			AmountType _rDomGainAmt = rDomGainAmt;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcAPGainLossSp";
				
				appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVoucher", _pVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendCurrCode", _pVendCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseHistRate", _pUseHistRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckNum", _pCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rDomGainAmt", _rDomGainAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rDomGainAmt = _rDomGainAmt;
				rInfobar = _rInfobar;
				
				return Severity;
			}
		}
	}
}
