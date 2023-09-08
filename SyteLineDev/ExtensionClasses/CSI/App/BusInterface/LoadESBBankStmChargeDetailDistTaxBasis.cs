//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargeDetailDistTaxBasis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmChargeDetailDistTaxBasis
	{
		int LoadESBBankStmChargeDetailDistTaxBasisSp(string StmDocumentID,
		                                             string AcctLineNumber,
		                                             string AcctEntryLineNumber,
		                                             string EntryDetailTranLineNumber,
		                                             string ChargesType,
		                                             string ChargeDetailType,
		                                             string ChargeDetailDistTaxBasisBaseType,
		                                             decimal? ChargeDetailDistTaxBasisBaseAmount,
		                                             string ChargeDetailDistTaxBasisBaseAmountCurrencyCode,
		                                             ref string InfoBar);
	}
	
	public class LoadESBBankStmChargeDetailDistTaxBasis : ILoadESBBankStmChargeDetailDistTaxBasis
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmChargeDetailDistTaxBasis(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmChargeDetailDistTaxBasisSp(string StmDocumentID,
		                                                    string AcctLineNumber,
		                                                    string AcctEntryLineNumber,
		                                                    string EntryDetailTranLineNumber,
		                                                    string ChargesType,
		                                                    string ChargeDetailType,
		                                                    string ChargeDetailDistTaxBasisBaseType,
		                                                    decimal? ChargeDetailDistTaxBasisBaseAmount,
		                                                    string ChargeDetailDistTaxBasisBaseAmountCurrencyCode,
		                                                    ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _ChargesType = ChargesType;
			MarkupElementValueType _ChargeDetailType = ChargeDetailType;
			MarkupElementValueType _ChargeDetailDistTaxBasisBaseType = ChargeDetailDistTaxBasisBaseType;
			DecimalType _ChargeDetailDistTaxBasisBaseAmount = ChargeDetailDistTaxBasisBaseAmount;
			MarkupElementValueType _ChargeDetailDistTaxBasisBaseAmountCurrencyCode = ChargeDetailDistTaxBasisBaseAmountCurrencyCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmChargeDetailDistTaxBasisSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargesType", _ChargesType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailType", _ChargeDetailType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxBasisBaseType", _ChargeDetailDistTaxBasisBaseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxBasisBaseAmount", _ChargeDetailDistTaxBasisBaseAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxBasisBaseAmountCurrencyCode", _ChargeDetailDistTaxBasisBaseAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
