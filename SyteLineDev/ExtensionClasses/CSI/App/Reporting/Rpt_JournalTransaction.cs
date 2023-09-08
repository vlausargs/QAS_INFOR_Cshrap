//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JournalTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JournalTransaction : IRpt_JournalTransaction
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JournalTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JournalTransactionSp(string CurId = null,
		string SiteGroup = null,
		int? StartingSeq = null,
		int? EndingSeq = null,
		DateTime? StartingTransDate = null,
		DateTime? EndingTransDate = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null,
		DateTime? StartingPeriod = null,
		DateTime? EndingPeriod = null,
		int? StartingPeriodOffset = null,
		int? EndingPeriodOffset = null,
		string StartingAcct = null,
		string EndingAcct = null,
		string StartingAcctUnit1 = null,
		string EndingAcctUnit1 = null,
		string StartingAcctUnit2 = null,
		string EndingAcctUnit2 = null,
		string StartingAcctUnit3 = null,
		string EndingAcctUnit3 = null,
		string StartingAcctUnit4 = null,
		string EndingAcctUnit4 = null,
		string StartingRef = null,
		string EndingRef = null,
		string SortBy = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? ShowDetail = null,
		int? GroupBy = 0,
		int? DisplayHeader = null,
		string pSite = null)
		{
			JournalIdType _CurId = CurId;
			SiteGroupType _SiteGroup = SiteGroup;
			JournalSeqType _StartingSeq = StartingSeq;
			JournalSeqType _EndingSeq = EndingSeq;
			DateType _StartingTransDate = StartingTransDate;
			DateType _EndingTransDate = EndingTransDate;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			DateType _StartingPeriod = StartingPeriod;
			DateType _EndingPeriod = EndingPeriod;
			DateOffsetType _StartingPeriodOffset = StartingPeriodOffset;
			DateOffsetType _EndingPeriodOffset = EndingPeriodOffset;
			AcctType _StartingAcct = StartingAcct;
			AcctType _EndingAcct = EndingAcct;
			UnitCode1Type _StartingAcctUnit1 = StartingAcctUnit1;
			UnitCode1Type _EndingAcctUnit1 = EndingAcctUnit1;
			UnitCode2Type _StartingAcctUnit2 = StartingAcctUnit2;
			UnitCode2Type _EndingAcctUnit2 = EndingAcctUnit2;
			UnitCode3Type _StartingAcctUnit3 = StartingAcctUnit3;
			UnitCode3Type _EndingAcctUnit3 = EndingAcctUnit3;
			UnitCode4Type _StartingAcctUnit4 = StartingAcctUnit4;
			UnitCode4Type _EndingAcctUnit4 = EndingAcctUnit4;
			ReferenceType _StartingRef = StartingRef;
			ReferenceType _EndingRef = EndingRef;
			StringType _SortBy = SortBy;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _ShowDetail = ShowDetail;
			ShortType _GroupBy = GroupBy;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JournalTransactionSp";
				
				appDB.AddCommandParameter(cmd, "CurId", _CurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingSeq", _StartingSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSeq", _EndingSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDate", _StartingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDate", _EndingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPeriod", _StartingPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPeriod", _EndingPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPeriodOffset", _StartingPeriodOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPeriodOffset", _EndingPeriodOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingAcct", _StartingAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAcct", _EndingAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingAcctUnit1", _StartingAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAcctUnit1", _EndingAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingAcctUnit2", _StartingAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAcctUnit2", _EndingAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingAcctUnit3", _StartingAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAcctUnit3", _EndingAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingAcctUnit4", _StartingAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAcctUnit4", _EndingAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingRef", _StartingRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingRef", _EndingRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupBy", _GroupBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
