//PROJECT NAME: CSIVendor
//CLASS NAME: GenerateLCVouchersPreUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGenerateLCVouchersPreUpd
	{
		int GenerateLCVouchersPreUpdSp(string VendNum,
		                               DateTime? InvoiceDate,
		                               DateTime? GLDistDate,
		                               string VendorInvoice,
		                               decimal? VendExchRate,
		                               decimal? AmtBrokerage,
		                               decimal? AmtDuty,
		                               decimal? AmtFreight,
		                               decimal? AmtLocFreight,
		                               decimal? AmtInsurance,
		                               ref string Infobar,
		                               decimal? AmtTax1,
		                               decimal? AmtTax2);
	}
	
	public class GenerateLCVouchersPreUpd : IGenerateLCVouchersPreUpd
	{
		readonly IApplicationDB appDB;
		
		public GenerateLCVouchersPreUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GenerateLCVouchersPreUpdSp(string VendNum,
		                                      DateTime? InvoiceDate,
		                                      DateTime? GLDistDate,
		                                      string VendorInvoice,
		                                      decimal? VendExchRate,
		                                      decimal? AmtBrokerage,
		                                      decimal? AmtDuty,
		                                      decimal? AmtFreight,
		                                      decimal? AmtLocFreight,
		                                      decimal? AmtInsurance,
		                                      ref string Infobar,
		                                      decimal? AmtTax1,
		                                      decimal? AmtTax2)
		{
			VendNumType _VendNum = VendNum;
			GenericDateType _InvoiceDate = InvoiceDate;
			GenericDateType _GLDistDate = GLDistDate;
			VendInvNumType _VendorInvoice = VendorInvoice;
			ExchRateType _VendExchRate = VendExchRate;
			AmountType _AmtBrokerage = AmtBrokerage;
			AmountType _AmtDuty = AmtDuty;
			AmountType _AmtFreight = AmtFreight;
			AmountType _AmtLocFreight = AmtLocFreight;
			AmountType _AmtInsurance = AmtInsurance;
			InfobarType _Infobar = Infobar;
			AmountType _AmtTax1 = AmtTax1;
			AmountType _AmtTax2 = AmtTax2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateLCVouchersPreUpdSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GLDistDate", _GLDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorInvoice", _VendorInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendExchRate", _VendExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtBrokerage", _AmtBrokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtDuty", _AmtDuty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtFreight", _AmtFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtLocFreight", _AmtLocFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtInsurance", _AmtInsurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AmtTax1", _AmtTax1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtTax2", _AmtTax2, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
