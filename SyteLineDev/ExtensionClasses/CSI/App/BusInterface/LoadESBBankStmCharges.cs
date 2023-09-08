//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmCharges.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmCharges
	{
		int LoadESBBankStmChargesSp(string StmDocumentID,
		                            string AcctLineNumber,
		                            string AcctEntryLineNumber,
		                            string EntryDetailTranLineNumber,
		                            string ChargesType,
		                            decimal? ChargesTotalAmount,
		                            string ChargesTotalAmountCurrencyCode,
		                            ref string InfoBar);
	}
	
	public class LoadESBBankStmCharges : ILoadESBBankStmCharges
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmCharges(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmChargesSp(string StmDocumentID,
		                                   string AcctLineNumber,
		                                   string AcctEntryLineNumber,
		                                   string EntryDetailTranLineNumber,
		                                   string ChargesType,
		                                   decimal? ChargesTotalAmount,
		                                   string ChargesTotalAmountCurrencyCode,
		                                   ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _ChargesType = ChargesType;
			DecimalType _ChargesTotalAmount = ChargesTotalAmount;
			MarkupElementValueType _ChargesTotalAmountCurrencyCode = ChargesTotalAmountCurrencyCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmChargesSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargesType", _ChargesType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargesTotalAmount", _ChargesTotalAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargesTotalAmountCurrencyCode", _ChargesTotalAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
