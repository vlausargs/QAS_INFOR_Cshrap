//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VAT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VAT : IRpt_VAT
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VAT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VATSp(int? TaxJurTaxSystem = null,
		int? ExOptszShowDetail = null,
		string TaxJurTaxJur = null,
		DateTime? ExBegInvStaxInvDate = null,
		DateTime? ExEndInvStaxInvDate = null,
		int? TaxDateStartingOffset = null,
		int? TaxDateEndingOffset = null,
		string ExOptgoJournalId = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null,
		string SortBy = null,
		int? ExcludeNullLineNum = 0,
		int? ExcludeJournalEntries = 0)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				TaxSystemType _TaxJurTaxSystem = TaxJurTaxSystem;
				ListYesNoType _ExOptszShowDetail = ExOptszShowDetail;
				TaxJurType _TaxJurTaxJur = TaxJurTaxJur;
				DateType _ExBegInvStaxInvDate = ExBegInvStaxInvDate;
				DateType _ExEndInvStaxInvDate = ExEndInvStaxInvDate;
				DateOffsetType _TaxDateStartingOffset = TaxDateStartingOffset;
				DateOffsetType _TaxDateEndingOffset = TaxDateEndingOffset;
				JournalIdType _ExOptgoJournalId = ExOptgoJournalId;
				ListYesNoType _DisplayHeader = DisplayHeader;
				StringType _BGSessionId = BGSessionId;
				TaskNumType _TaskId = TaskId;
				SiteType _pSite = pSite;
				UsernameType _BGUser = BGUser;
				InfobarType _SortBy = SortBy;
				ListYesNoType _ExcludeNullLineNum = ExcludeNullLineNum;
				ListYesNoType _ExcludeJournalEntries = ExcludeJournalEntries;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "Rpt_VATSp";
					
					appDB.AddCommandParameter(cmd, "TaxJurTaxSystem", _TaxJurTaxSystem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExOptszShowDetail", _ExOptszShowDetail, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TaxJurTaxJur", _TaxJurTaxJur, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExBegInvStaxInvDate", _ExBegInvStaxInvDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExEndInvStaxInvDate", _ExEndInvStaxInvDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TaxDateStartingOffset", _TaxDateStartingOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TaxDateEndingOffset", _TaxDateEndingOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExOptgoJournalId", _ExOptgoJournalId, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExcludeNullLineNum", _ExcludeNullLineNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExcludeJournalEntries", _ExcludeJournalEntries, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
