//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECVAT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ECVAT : IRpt_ECVAT
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ECVAT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECVATsp(int? TaxJurTaxSystem = null,
		int? ExOptszShowDetail = null,
		string TaxJurTaxJur = null,
		DateTime? ExBegInvStaxInvDate = null,
		DateTime? ExEndInvStaxInvDate = null,
		int? ExOptprPostTrx = null,
		int? TaxDateStartingOffset = null,
		int? TaxDateEndingOffset = null,
		string ExOptgoJournalId = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null)
		{
			TaxSystemType _TaxJurTaxSystem = TaxJurTaxSystem;
			ListYesNoType _ExOptszShowDetail = ExOptszShowDetail;
			TaxJurType _TaxJurTaxJur = TaxJurTaxJur;
			DateType _ExBegInvStaxInvDate = ExBegInvStaxInvDate;
			DateType _ExEndInvStaxInvDate = ExEndInvStaxInvDate;
			ListYesNoType _ExOptprPostTrx = ExOptprPostTrx;
			DateOffsetType _TaxDateStartingOffset = TaxDateStartingOffset;
			DateOffsetType _TaxDateEndingOffset = TaxDateEndingOffset;
			JournalIdType _ExOptgoJournalId = ExOptgoJournalId;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ECVATsp";
				
				appDB.AddCommandParameter(cmd, "TaxJurTaxSystem", _TaxJurTaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszShowDetail", _ExOptszShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxJurTaxJur", _TaxJurTaxJur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegInvStaxInvDate", _ExBegInvStaxInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndInvStaxInvDate", _ExEndInvStaxInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostTrx", _ExOptprPostTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxDateStartingOffset", _TaxDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxDateEndingOffset", _TaxDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoJournalId", _ExOptgoJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
