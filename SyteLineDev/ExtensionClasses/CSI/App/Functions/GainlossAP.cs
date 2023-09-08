//PROJECT NAME: Data
//CLASS NAME: GainLossAP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GainLossAP : IGainLossAP
	{
		readonly IApplicationDB appDB;
		
		public GainLossAP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? rTDomBal,
			decimal? rTForBal,
			decimal? rTGainLoss,
			string rInfobar) GainLossAPSp(
			string pVendNum,
			int? pVoucher,
			string pVendCurrCode,
			int? pUseHistRate,
			DateTime? pPCutoffDate = null,
			string pSite = null,
			int? pCheckNum = 0,
			decimal? rTDomBal = 0,
			decimal? rTForBal = 0,
			decimal? rTGainLoss = 0,
			string rInfobar = null)
		{
			VendNumType _pVendNum = pVendNum;
			VoucherType _pVoucher = pVoucher;
			CurrCodeType _pVendCurrCode = pVendCurrCode;
			ListYesNoType _pUseHistRate = pUseHistRate;
			DateType _pPCutoffDate = pPCutoffDate;
			SiteType _pSite = pSite;
			ApCheckNumType _pCheckNum = pCheckNum;
			AmountType _rTDomBal = rTDomBal;
			AmountType _rTForBal = rTForBal;
			AmountType _rTGainLoss = rTGainLoss;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GainLossAPSp";
				
				appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVoucher", _pVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendCurrCode", _pVendCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseHistRate", _pUseHistRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPCutoffDate", _pPCutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckNum", _pCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rTDomBal", _rTDomBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rTForBal", _rTForBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rTGainLoss", _rTGainLoss, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rTDomBal = _rTDomBal;
				rTForBal = _rTForBal;
				rTGainLoss = _rTGainLoss;
				rInfobar = _rInfobar;
				
				return (Severity, rTDomBal, rTForBal, rTGainLoss, rInfobar);
			}
		}
	}
}
