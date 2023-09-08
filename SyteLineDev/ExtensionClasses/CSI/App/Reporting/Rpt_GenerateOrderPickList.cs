//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GenerateOrderPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_GenerateOrderPickList : IRpt_GenerateOrderPickList
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_GenerateOrderPickList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_GenerateOrderPickListSp(string PSessionIdChar = null,
		string PStartCoNum = null,
		string PEndCoNum = null,
		DateTime? PStartDueDate = null,
		DateTime? PEndDueDate = null,
		string PStartWhse = null,
		string PEndWhse = null,
		string PStartCustNum = null,
		string PEndCustNum = null,
		int? PStartCustSeq = null,
		int? PEndCustSeq = null,
		string PParmsSite = null,
		DateTime? PPostDate = null,
		int? PPostMatlIssues = null,
		int? PBarLoc = null,
		int? PShowExternal = null,
		int? PShowInternal = null,
		int? PDisplayHeader = null,
		int? PPrintBc = null,
		int? PPrint80 = null,
		string PDetSummBoth = null,
		string PPrItemCi = null,
		int? PPrSerialNumbers = null,
		int? PPrPlanItemMatl = null,
		int? PPrStdOrderText = null,
		int? PDisplayDescription = null,
		int? PListByLoc = null,
		string PPickwarn = null,
		int? PSuppressErrorWhenCustomerLcrNotReqd = null,
		int? PSkipOrderLineCycCnt = null,
		int? PProcessBatchId = null,
		int? TaskId = null,
		int? pPrintManufacturerItem = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? PostDateOffset = null,
		string pSite = null,
		decimal? UserID = null)
		{
			StringType _PSessionIdChar = PSessionIdChar;
			CoNumType _PStartCoNum = PStartCoNum;
			CoNumType _PEndCoNum = PEndCoNum;
			DateType _PStartDueDate = PStartDueDate;
			DateType _PEndDueDate = PEndDueDate;
			WhseType _PStartWhse = PStartWhse;
			WhseType _PEndWhse = PEndWhse;
			CustNumType _PStartCustNum = PStartCustNum;
			CustNumType _PEndCustNum = PEndCustNum;
			CustSeqType _PStartCustSeq = PStartCustSeq;
			CustSeqType _PEndCustSeq = PEndCustSeq;
			SiteType _PParmsSite = PParmsSite;
			DateType _PPostDate = PPostDate;
			ListYesNoType _PPostMatlIssues = PPostMatlIssues;
			ListYesNoType _PBarLoc = PBarLoc;
			FlagNyType _PShowExternal = PShowExternal;
			FlagNyType _PShowInternal = PShowInternal;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			ListYesNoType _PPrintBc = PPrintBc;
			ListYesNoType _PPrint80 = PPrint80;
			StringType _PDetSummBoth = PDetSummBoth;
			StringType _PPrItemCi = PPrItemCi;
			ListYesNoType _PPrSerialNumbers = PPrSerialNumbers;
			ListYesNoType _PPrPlanItemMatl = PPrPlanItemMatl;
			ListYesNoType _PPrStdOrderText = PPrStdOrderText;
			FlagNyType _PDisplayDescription = PDisplayDescription;
			ListYesNoType _PListByLoc = PListByLoc;
			StringType _PPickwarn = PPickwarn;
			ListYesNoType _PSuppressErrorWhenCustomerLcrNotReqd = PSuppressErrorWhenCustomerLcrNotReqd;
			ListYesNoType _PSkipOrderLineCycCnt = PSkipOrderLineCycCnt;
			BatchIdType _PProcessBatchId = PProcessBatchId;
			TaskNumType _TaskId = TaskId;
			ListYesNoType _pPrintManufacturerItem = pPrintManufacturerItem;
			DateOffsetType _DueDateStartingOffset = DueDateStartingOffset;
			DateOffsetType _DueDateEndingOffset = DueDateEndingOffset;
			DateOffsetType _PostDateOffset = PostDateOffset;
			SiteType _pSite = pSite;
			TokenType _UserID = UserID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_GenerateOrderPickListSp";
				
				appDB.AddCommandParameter(cmd, "PSessionIdChar", _PSessionIdChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartCoNum", _PStartCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCoNum", _PEndCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDueDate", _PStartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDueDate", _PEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartWhse", _PStartWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndWhse", _PEndWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartCustNum", _PStartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCustNum", _PEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartCustSeq", _PStartCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCustSeq", _PEndCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParmsSite", _PParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostMatlIssues", _PPostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBarLoc", _PBarLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowExternal", _PShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowInternal", _PShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintBc", _PPrintBc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrint80", _PPrint80, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDetSummBoth", _PDetSummBoth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrItemCi", _PPrItemCi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrSerialNumbers", _PPrSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrPlanItemMatl", _PPrPlanItemMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrStdOrderText", _PPrStdOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayDescription", _PDisplayDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PListByLoc", _PListByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPickwarn", _PPickwarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuppressErrorWhenCustomerLcrNotReqd", _PSuppressErrorWhenCustomerLcrNotReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSkipOrderLineCycCnt", _PSkipOrderLineCycCnt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessBatchId", _PProcessBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintManufacturerItem", _pPrintManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStartingOffset", _DueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEndingOffset", _DueDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDateOffset", _PostDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
