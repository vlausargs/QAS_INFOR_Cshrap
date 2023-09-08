//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PORequisition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PORequisition : IRpt_PORequisition
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PORequisition(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PORequisitionSp(string ReqStat = null,
		string ReqitemStat = null,
		string QuotedTp = null,
		string SortBy = null,
		string StartReqNum = null,
		string EndReqNum = null,
		int? StartReqLine = null,
		int? EndReqLine = null,
		string StartVendor = null,
		string EndVendor = null,
		string StartBuyer = null,
		string EndBuyer = null,
		string StartApprover = null,
		string EndApprover = null,
		string StartRequester = null,
		string EndRequester = null,
		string StartReqCode = null,
		string EndReqCode = null,
		DateTime? StartDueDate = null,
		DateTime? EndDueDate = null,
		DateTime? StartRelDate = null,
		DateTime? EndRelDate = null,
		int? StartDueDateOffset = null,
		int? EndDueDateOffset = null,
		int? StartRelDateOffset = null,
		int? EndRelDateOffset = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		string PMessageLanguage = null,
		int? TransDomCurr = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null)
		{
			StringType _ReqStat = ReqStat;
			StringType _ReqitemStat = ReqitemStat;
			StringType _QuotedTp = QuotedTp;
			StringType _SortBy = SortBy;
			ReqNumType _StartReqNum = StartReqNum;
			ReqNumType _EndReqNum = EndReqNum;
			ReqLineType _StartReqLine = StartReqLine;
			ReqLineType _EndReqLine = EndReqLine;
			VendNumType _StartVendor = StartVendor;
			VendNumType _EndVendor = EndVendor;
			NameType _StartBuyer = StartBuyer;
			NameType _EndBuyer = EndBuyer;
			NameType _StartApprover = StartApprover;
			NameType _EndApprover = EndApprover;
			NameType _StartRequester = StartRequester;
			NameType _EndRequester = EndRequester;
			ReqCodeType _StartReqCode = StartReqCode;
			ReqCodeType _EndReqCode = EndReqCode;
			GenericDateType _StartDueDate = StartDueDate;
			GenericDateType _EndDueDate = EndDueDate;
			GenericDateType _StartRelDate = StartRelDate;
			GenericDateType _EndRelDate = EndRelDate;
			DateOffsetType _StartDueDateOffset = StartDueDateOffset;
			DateOffsetType _EndDueDateOffset = EndDueDateOffset;
			DateOffsetType _StartRelDateOffset = StartRelDateOffset;
			DateOffsetType _EndRelDateOffset = EndRelDateOffset;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			FlagNyType _TransDomCurr = TransDomCurr;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PORequisitionSp";
				
				appDB.AddCommandParameter(cmd, "ReqStat", _ReqStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqitemStat", _ReqitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuotedTp", _QuotedTp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReqNum", _StartReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReqNum", _EndReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReqLine", _StartReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReqLine", _EndReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendor", _StartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendor", _EndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartBuyer", _StartBuyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBuyer", _EndBuyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartApprover", _StartApprover, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndApprover", _EndApprover, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRequester", _StartRequester, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRequester", _EndRequester, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReqCode", _StartReqCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReqCode", _EndReqCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRelDate", _StartRelDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRelDate", _EndRelDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDateOffset", _StartDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDateOffset", _EndDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRelDateOffset", _StartRelDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRelDateOffset", _EndRelDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
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
