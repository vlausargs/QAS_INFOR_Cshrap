//PROJECT NAME: Finance
//CLASS NAME: MXVATPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXVATPost : IMXVATPost
	{
		readonly IApplicationDB appDB;
		
		public MXVATPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MXVATPostSp(
			string JournalID,
			string CustNum,
			string InvNum,
			int? InvSeq,
			DateTime? DistDate,
			DateTime? EffDate,
			string VatAcct,
			decimal? AmountPaid,
			decimal? AmountInvoice,
			string CurrCode,
			decimal? TaxAmount,
			decimal? TaxForAmount,
			decimal? DomVATTaxBasis,
			decimal? ForVATTaxBasis,
			decimal? DomInvTaxAmount,
			decimal? ForInvTaxAmount,
			decimal? DomInvTaxBasis,
			decimal? ForInvTaxBasis,
			decimal? DomArCheckAmt,
			decimal? ForArCheckAmt,
			decimal? DomArInvCheckAmt,
			decimal? ForArInvCheckAmt,
			int? TaxSeq,
			string TaxCode,
			decimal? TaxRate,
			string VendNum,
			int? Voucher,
			int? CheckNum,
			decimal? InvExchRate,
			decimal? ChkExchRate,
			decimal? GainLose)
		{
			JournalIdType _JournalID = JournalID;
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			DateType _DistDate = DistDate;
			DateType _EffDate = EffDate;
			AcctType _VatAcct = VatAcct;
			AmountType _AmountPaid = AmountPaid;
			AmountType _AmountInvoice = AmountInvoice;
			CurrCodeType _CurrCode = CurrCode;
			AmountType _TaxAmount = TaxAmount;
			AmountType _TaxForAmount = TaxForAmount;
			AmountType _DomVATTaxBasis = DomVATTaxBasis;
			AmountType _ForVATTaxBasis = ForVATTaxBasis;
			AmountType _DomInvTaxAmount = DomInvTaxAmount;
			AmountType _ForInvTaxAmount = ForInvTaxAmount;
			AmountType _DomInvTaxBasis = DomInvTaxBasis;
			AmountType _ForInvTaxBasis = ForInvTaxBasis;
			AmountType _DomArCheckAmt = DomArCheckAmt;
			AmountType _ForArCheckAmt = ForArCheckAmt;
			AmountType _DomArInvCheckAmt = DomArInvCheckAmt;
			AmountType _ForArInvCheckAmt = ForArInvCheckAmt;
			StaxSeqType _TaxSeq = TaxSeq;
			TaxCodeType _TaxCode = TaxCode;
			TaxRateType _TaxRate = TaxRate;
			VendNumType _VendNum = VendNum;
			VoucherType _Voucher = Voucher;
			GlCheckNumType _CheckNum = CheckNum;
			ExchRateType _InvExchRate = InvExchRate;
			ExchRateType _ChkExchRate = ChkExchRate;
			AmountType _GainLose = GainLose;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXVATPostSp";
				
				appDB.AddCommandParameter(cmd, "JournalID", _JournalID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDate", _DistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VatAcct", _VatAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmountPaid", _AmountPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmountInvoice", _AmountInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmount", _TaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxForAmount", _TaxForAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomVATTaxBasis", _DomVATTaxBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForVATTaxBasis", _ForVATTaxBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomInvTaxAmount", _DomInvTaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForInvTaxAmount", _ForInvTaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomInvTaxBasis", _DomInvTaxBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForInvTaxBasis", _ForInvTaxBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomArCheckAmt", _DomArCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForArCheckAmt", _ForArCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomArInvCheckAmt", _DomArInvCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForArInvCheckAmt", _ForArInvCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxSeq", _TaxSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxRate", _TaxRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvExchRate", _InvExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChkExchRate", _ChkExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GainLose", _GainLose, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
