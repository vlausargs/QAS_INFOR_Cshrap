//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjInvTrxPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjInvTrxPost : IRpt_ProjInvTrxPost
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjInvTrxPost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjInvTrxPostSp(string StartingProjNum = null,
		string EndingProjNum = null,
		string StartingInvMsNum = null,
		string EndingInvMsNum = null,
		int? EndPeriod = null,
		int? FiscalYear = null,
		DateTime? PostDate = null,
		string PostLevel = null,
		int? PrintMilestoneNotes = null,
		int? PrintCustomerNotes = null,
		int? PrintProjectNotes = null,
		int? PrintStandardNotes = null,
		int? PrintEuroTotal = null,
		int? XLateToDomestic = null,
		int? DoPost = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		int? TransReport = null,
		int? TaskID = null,
		string Username = null,
		string BGSessionId = null,
		int? PrintDiscountAmt = 0,
		string pSite = null,
		string BGUser = null)
		{
			ProjNumType _StartingProjNum = StartingProjNum;
			ProjNumType _EndingProjNum = EndingProjNum;
			ProjMsNumType _StartingInvMsNum = StartingInvMsNum;
			ProjMsNumType _EndingInvMsNum = EndingInvMsNum;
			FinPeriodType _EndPeriod = EndPeriod;
			FiscalYearType _FiscalYear = FiscalYear;
			DateType _PostDate = PostDate;
			StringType _PostLevel = PostLevel;
			ListYesNoType _PrintMilestoneNotes = PrintMilestoneNotes;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _PrintProjectNotes = PrintProjectNotes;
			ListYesNoType _PrintStandardNotes = PrintStandardNotes;
			ListYesNoType _PrintEuroTotal = PrintEuroTotal;
			ListYesNoType _XLateToDomestic = XLateToDomestic;
			ListYesNoType _DoPost = DoPost;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			FlagNyType _TransReport = TransReport;
			TaskNumType _TaskID = TaskID;
			UsernameType _Username = Username;
			StringType _BGSessionId = BGSessionId;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjInvTrxPostSp";
				
				appDB.AddCommandParameter(cmd, "StartingProjNum", _StartingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProjNum", _EndingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvMsNum", _StartingInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvMsNum", _EndingInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostLevel", _PostLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintMilestoneNotes", _PrintMilestoneNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProjectNotes", _PrintProjectNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardNotes", _PrintStandardNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuroTotal", _PrintEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XLateToDomestic", _XLateToDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoPost", _DoPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransReport", _TransReport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
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
