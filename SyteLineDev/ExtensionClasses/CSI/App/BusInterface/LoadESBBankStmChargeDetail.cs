//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargeDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmChargeDetail
	{
		int LoadESBBankStmChargeDetailSp(string StmDocumentID,
		                                 string AcctLineNumber,
		                                 string AcctEntryLineNumber,
		                                 string EntryDetailTranLineNumber,
		                                 string ChargesType,
		                                 string ChargeDetailType,
		                                 string ChargeDetailBearer,
		                                 decimal? ChargeDetailAmount,
		                                 string ChargeDetailAmountCurrencyCode,
		                                 string ChargeDetailAmountDebitCreditFlag,
		                                 string ChargeDetailChargeIncludedIndicator,
		                                 decimal? ChargeDetailChargeRate,
		                                 ref string InfoBar);
	}
	
	public class LoadESBBankStmChargeDetail : ILoadESBBankStmChargeDetail
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmChargeDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmChargeDetailSp(string StmDocumentID,
		                                        string AcctLineNumber,
		                                        string AcctEntryLineNumber,
		                                        string EntryDetailTranLineNumber,
		                                        string ChargesType,
		                                        string ChargeDetailType,
		                                        string ChargeDetailBearer,
		                                        decimal? ChargeDetailAmount,
		                                        string ChargeDetailAmountCurrencyCode,
		                                        string ChargeDetailAmountDebitCreditFlag,
		                                        string ChargeDetailChargeIncludedIndicator,
		                                        decimal? ChargeDetailChargeRate,
		                                        ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _ChargesType = ChargesType;
			MarkupElementValueType _ChargeDetailType = ChargeDetailType;
			MarkupElementValueType _ChargeDetailBearer = ChargeDetailBearer;
			DecimalType _ChargeDetailAmount = ChargeDetailAmount;
			MarkupElementValueType _ChargeDetailAmountCurrencyCode = ChargeDetailAmountCurrencyCode;
			MarkupElementValueType _ChargeDetailAmountDebitCreditFlag = ChargeDetailAmountDebitCreditFlag;
			MarkupElementValueType _ChargeDetailChargeIncludedIndicator = ChargeDetailChargeIncludedIndicator;
			DecimalType _ChargeDetailChargeRate = ChargeDetailChargeRate;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmChargeDetailSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargesType", _ChargesType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailType", _ChargeDetailType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailBearer", _ChargeDetailBearer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailAmount", _ChargeDetailAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailAmountCurrencyCode", _ChargeDetailAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailAmountDebitCreditFlag", _ChargeDetailAmountDebitCreditFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailChargeIncludedIndicator", _ChargeDetailChargeIncludedIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailChargeRate", _ChargeDetailChargeRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
