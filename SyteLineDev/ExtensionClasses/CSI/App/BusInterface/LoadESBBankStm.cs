//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStm
	{
		int LoadESBBankStmSp(string StmDocumentID,
		                     DateTime? StmLastModificationDateTime,
		                     string StmLastModificationPersonName,
		                     DateTime? StmDocumentDateTime,
		                     string StmStatusCode,
		                     DateTime? StmEffectiveDateTime,
		                     string StmStatusReasonCode,
		                     string StmFInancialPartyID,
		                     string StmFinancialPartyBIC,
		                     string StmFinacialPartyClearingSystemMemberID,
		                     string StmRecepientPartyID,
		                     string StmRecepientPartyIDSchemaName,
		                     string StmRecepientPartyBIC,
		                     ref string InfoBar);
	}
	
	public class LoadESBBankStm : ILoadESBBankStm
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmSp(string StmDocumentID,
		                            DateTime? StmLastModificationDateTime,
		                            string StmLastModificationPersonName,
		                            DateTime? StmDocumentDateTime,
		                            string StmStatusCode,
		                            DateTime? StmEffectiveDateTime,
		                            string StmStatusReasonCode,
		                            string StmFInancialPartyID,
		                            string StmFinancialPartyBIC,
		                            string StmFinacialPartyClearingSystemMemberID,
		                            string StmRecepientPartyID,
		                            string StmRecepientPartyIDSchemaName,
		                            string StmRecepientPartyBIC,
		                            ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			DateTimeType _StmLastModificationDateTime = StmLastModificationDateTime;
			MarkupElementValueType _StmLastModificationPersonName = StmLastModificationPersonName;
			DateTimeType _StmDocumentDateTime = StmDocumentDateTime;
			MarkupElementValueType _StmStatusCode = StmStatusCode;
			DateTimeType _StmEffectiveDateTime = StmEffectiveDateTime;
			MarkupElementValueType _StmStatusReasonCode = StmStatusReasonCode;
			MarkupElementValueType _StmFInancialPartyID = StmFInancialPartyID;
			MarkupElementValueType _StmFinancialPartyBIC = StmFinancialPartyBIC;
			MarkupElementValueType _StmFinacialPartyClearingSystemMemberID = StmFinacialPartyClearingSystemMemberID;
			MarkupElementValueType _StmRecepientPartyID = StmRecepientPartyID;
			MarkupElementValueType _StmRecepientPartyIDSchemaName = StmRecepientPartyIDSchemaName;
			MarkupElementValueType _StmRecepientPartyBIC = StmRecepientPartyBIC;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmLastModificationDateTime", _StmLastModificationDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmLastModificationPersonName", _StmLastModificationPersonName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmDocumentDateTime", _StmDocumentDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmStatusCode", _StmStatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmEffectiveDateTime", _StmEffectiveDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmStatusReasonCode", _StmStatusReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmFInancialPartyID", _StmFInancialPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmFinancialPartyBIC", _StmFinancialPartyBIC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmFinacialPartyClearingSystemMemberID", _StmFinacialPartyClearingSystemMemberID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmRecepientPartyID", _StmRecepientPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmRecepientPartyIDSchemaName", _StmRecepientPartyIDSchemaName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StmRecepientPartyBIC", _StmRecepientPartyBIC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
