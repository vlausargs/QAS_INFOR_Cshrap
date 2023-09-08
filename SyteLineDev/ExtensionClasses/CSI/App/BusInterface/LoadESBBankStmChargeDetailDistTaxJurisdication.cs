//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargeDetailDistTaxJurisdication.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmChargeDetailDistTaxJurisdication
	{
		int LoadESBBankStmChargeDetailDistTaxJurisdicationSp(string StmDocumentID,
		                                                     string AcctLineNumber,
		                                                     string AcctEntryLineNumber,
		                                                     string EntryDetailTranLineNumber,
		                                                     string ChargesType,
		                                                     string ChargeDetailType,
		                                                     string ChargeDetailDistTaxJurisdicationCode,
		                                                     ref string InfoBar);
	}
	
	public class LoadESBBankStmChargeDetailDistTaxJurisdication : ILoadESBBankStmChargeDetailDistTaxJurisdication
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmChargeDetailDistTaxJurisdication(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmChargeDetailDistTaxJurisdicationSp(string StmDocumentID,
		                                                            string AcctLineNumber,
		                                                            string AcctEntryLineNumber,
		                                                            string EntryDetailTranLineNumber,
		                                                            string ChargesType,
		                                                            string ChargeDetailType,
		                                                            string ChargeDetailDistTaxJurisdicationCode,
		                                                            ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _ChargesType = ChargesType;
			MarkupElementValueType _ChargeDetailType = ChargeDetailType;
			MarkupElementValueType _ChargeDetailDistTaxJurisdicationCode = ChargeDetailDistTaxJurisdicationCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmChargeDetailDistTaxJurisdicationSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargesType", _ChargesType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailType", _ChargeDetailType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeDetailDistTaxJurisdicationCode", _ChargeDetailDistTaxJurisdicationCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
