//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjRetTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjRetTrans : IRpt_ProjRetTrans
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjRetTrans(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjRetTransSp(string StartingProjNum = null,
		string EndingProjNum = null,
		DateTime? PostDate = null,
		string InvoiceText = "PLS",
		int? PrintEuroTotal = 0,
		int? XLateToDomestic = 0,
		int? DoPost = 0,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? DisplayHeader = 1,
		int? TransReport = 1,
		decimal? UserId = null,
		string BGSessionId = null,
		string pSite = null)
		{
			ProjNumType _StartingProjNum = StartingProjNum;
			ProjNumType _EndingProjNum = EndingProjNum;
			DateType _PostDate = PostDate;
			InfobarType _InvoiceText = InvoiceText;
			FlagNyType _PrintEuroTotal = PrintEuroTotal;
			FlagNyType _XLateToDomestic = XLateToDomestic;
			FlagNyType _DoPost = DoPost;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DisplayHeader = DisplayHeader;
			FlagNyType _TransReport = TransReport;
			TokenType _UserId = UserId;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjRetTransSp";
				
				appDB.AddCommandParameter(cmd, "StartingProjNum", _StartingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProjNum", _EndingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceText", _InvoiceText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuroTotal", _PrintEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XLateToDomestic", _XLateToDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoPost", _DoPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransReport", _TransReport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
