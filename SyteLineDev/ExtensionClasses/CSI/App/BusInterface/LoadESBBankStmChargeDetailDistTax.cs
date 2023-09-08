//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargeDetailDistTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmChargeDetailDistTax
	{
		int LoadESBBankStmChargeDetailDistTaxSp(string StmDocumentID,
		                                        string AcctLineNumber,
		                                        string AcctEntryLineNumber,
		                                        string EntryDetailTranLineNumber,
		                                        string ChargesType,
		                                        string ChargeDetailType,
		                                        string ChargeDetailDistTaxID,
		                                        decimal? ChargeDetailDistTaxBaseAmount,
		                                        string ChargeDetailDistTaxBaseAmountCurrencyCode,
		                                        decimal? ChargeDetailDistTaxBasisQuantity,
		                                        string ChargeDetailDistTaxBasisBaseUOMQuantity,
		                                        string ChargeDetailDistTaxExemptionID,
		                                        string ChargeDetailDistTaxExemptionType,
		                                        decimal? ChargeDetailDistTaxExemptionAmount,
		                                        string ChargeDetailDistTaxExemptionAmountCurrencyCode,
		                                        decimal? ChargeDetailDistTaxTaxAuthorityAmount,
		                                        string ChargeDetailDistTaxTaxAuthorityAmountCurrencyCode,
		                                        decimal? ChargeDetailDistTaxTaxAmount,
		                                        string ChargeDetailDistTaxTaxAmountCurrencyCode,
		                                        ref string InfoBar);
	}
	
	public class LoadESBBankStmChargeDetailDistTax : ILoadESBBankStmChargeDetailDistTax
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmChargeDetailDistTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmChargeDetailDistTaxSp(string StmDocumentID,
		                                               string AcctLineNumber,
		                                               string AcctEntryLineNumber,
		                                               string EntryDetailTranLineNumber,
		                                               string ChargesType,
		                                               string ChargeDetailType,
		                                               string ChargeDetailDistTaxID,
		                                               decimal? ChargeDetailDistTaxBaseAmount,
		                                               string ChargeDetailDistTaxBaseAmountCurrencyCode,
		                                               decimal? ChargeDetailDistTaxBasisQuantity,
		                                               string ChargeDetailDistTaxBasisBaseUOMQuantity,
		                                               string ChargeDetailDistTaxExemptionID,
		                                               string ChargeDetailDistTaxExemptionType,
		                                               decimal? ChargeDetailDistTaxExemptionAmount,
		                                               string ChargeDetailDistTaxExemptionAmountCurrencyCode,
		                                               decimal? ChargeDetailDistTaxTaxAuthorityAmount,
		                                               string ChargeDetailDistTaxTaxAuthorityAmountCurrencyCode,
		                                               decimal? ChargeDetailDistTaxTaxAmount,
		                                               string ChargeDetailDistTaxTaxAmountCurrencyCode,
		                                               ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _ChargesType = ChargesType;
			MarkupElementValueType _ChargeDetailType = ChargeDetailType;
			MarkupElementValueType _ChargeDetailDistTaxID = ChargeDetailDistTaxID;
			DecimalType _ChargeDetailDistTaxBaseAmount = ChargeDetailDistTaxBaseAmount;
			MarkupElementValueType _ChargeDetailDistTaxBaseAmountCurrencyCode = ChargeDetailDistTaxBaseAmountCurrencyCode;
			DecimalType _ChargeDetailDistTaxBasisQuantity = ChargeDetailDistTaxBasisQuantity;
			MarkupElementValueType _ChargeDetailDistTaxBasisBaseUOMQuantity = ChargeDetailDistTaxBasisBaseUOMQuantity;
			MarkupElementValueType _ChargeDetailDistTaxExemptionID = ChargeDetailDistTaxExemptionID;
			MarkupElementValueType _ChargeDetailDistTaxExemptionType = ChargeDetailDistTaxExemptionType;
			DecimalType _ChargeDetailDistTaxExemptionAmount = ChargeDetailDistTaxExemptionAmount;
			MarkupElementValueType _ChargeDetailDistTaxExemptionAmountCurrencyCode = ChargeDetailDistTaxExemptionAmountCurrencyCode;
			DecimalType _ChargeDetailDistTaxTaxAuthorityAmount = ChargeDetailDistTaxTaxAuthorityAmount;
			MarkupElementValueType _ChargeDetailDistTaxTaxAuthorityAmountCurrencyCode = ChargeDetailDistTaxTaxAuthorityAmountCurrencyCode;
			DecimalType _ChargeDetailDistTaxTaxAmount = ChargeDetailDistTaxTaxAmount;
			MarkupElementValueType _ChargeDetailDistTaxTaxAmountCurrencyCode = ChargeDetailDistTaxTaxAmountCurrencyCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmChargeDetailDistTaxSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargesType", _ChargesType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailType", _ChargeDetailType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxID", _ChargeDetailDistTaxID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxBaseAmount", _ChargeDetailDistTaxBaseAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxBaseAmountCurrencyCode", _ChargeDetailDistTaxBaseAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxBasisQuantity", _ChargeDetailDistTaxBasisQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxBasisBaseUOMQuantity", _ChargeDetailDistTaxBasisBaseUOMQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxExemptionID", _ChargeDetailDistTaxExemptionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxExemptionType", _ChargeDetailDistTaxExemptionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxExemptionAmount", _ChargeDetailDistTaxExemptionAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxExemptionAmountCurrencyCode", _ChargeDetailDistTaxExemptionAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxTaxAuthorityAmount", _ChargeDetailDistTaxTaxAuthorityAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxTaxAuthorityAmountCurrencyCode", _ChargeDetailDistTaxTaxAuthorityAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxTaxAmount", _ChargeDetailDistTaxTaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxTaxAmountCurrencyCode", _ChargeDetailDistTaxTaxAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
