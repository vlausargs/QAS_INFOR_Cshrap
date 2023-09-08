//PROJECT NAME: CSIVendor
//CLASS NAME: PurchaseOrdResetAccumTotals.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPurchaseOrdResetAccumTotals
	{
		int PurchaseOrdResetAccumTotalsSp(string StartPoNum,
		                                  string EndPoNum,
		                                  decimal? MiscChargeAmt,
		                                  decimal? SalesTaxAmt,
		                                  decimal? SalesTax2Amt,
		                                  decimal? FreightAmt,
		                                  decimal? DutyAmt,
		                                  decimal? BrokerageAmt,
		                                  decimal? InsuranceAmt,
		                                  decimal? LocalFreightAmt,
		                                  ref string Infobar);
	}
	
	public class PurchaseOrdResetAccumTotals : IPurchaseOrdResetAccumTotals
	{
		readonly IApplicationDB appDB;
		
		public PurchaseOrdResetAccumTotals(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PurchaseOrdResetAccumTotalsSp(string StartPoNum,
		                                         string EndPoNum,
		                                         decimal? MiscChargeAmt,
		                                         decimal? SalesTaxAmt,
		                                         decimal? SalesTax2Amt,
		                                         decimal? FreightAmt,
		                                         decimal? DutyAmt,
		                                         decimal? BrokerageAmt,
		                                         decimal? InsuranceAmt,
		                                         decimal? LocalFreightAmt,
		                                         ref string Infobar)
		{
			PoNumType _StartPoNum = StartPoNum;
			PoNumType _EndPoNum = EndPoNum;
			AmountType _MiscChargeAmt = MiscChargeAmt;
			AmountType _SalesTaxAmt = SalesTaxAmt;
			AmountType _SalesTax2Amt = SalesTax2Amt;
			AmountType _FreightAmt = FreightAmt;
			AmountType _DutyAmt = DutyAmt;
			AmountType _BrokerageAmt = BrokerageAmt;
			AmountType _InsuranceAmt = InsuranceAmt;
			AmountType _LocalFreightAmt = LocalFreightAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurchaseOrdResetAccumTotalsSp";
				
				appDB.AddCommandParameter(cmd, "StartPoNum", _StartPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPoNum", _EndPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscChargeAmt", _MiscChargeAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTaxAmt", _SalesTaxAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax2Amt", _SalesTax2Amt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightAmt", _FreightAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DutyAmt", _DutyAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrokerageAmt", _BrokerageAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsuranceAmt", _InsuranceAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocalFreightAmt", _LocalFreightAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
