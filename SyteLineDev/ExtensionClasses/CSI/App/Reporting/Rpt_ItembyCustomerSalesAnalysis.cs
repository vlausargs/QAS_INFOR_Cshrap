//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItembyCustomerSalesAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItembyCustomerSalesAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItembyCustomerSalesAnalysisSP(string CustNumStarting = null,
		string CustNumEnding = null,
		DateTime? AsOfDate = null,
		short? AsOfDateOffset = null,
		byte? ShowDetail = null,
		byte? PageBetweenItems = null,
		byte? PrintPrice = (byte)0,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
	
	public class Rpt_ItembyCustomerSalesAnalysis : IRpt_ItembyCustomerSalesAnalysis
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItembyCustomerSalesAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItembyCustomerSalesAnalysisSP(string CustNumStarting = null,
		string CustNumEnding = null,
		DateTime? AsOfDate = null,
		short? AsOfDateOffset = null,
		byte? ShowDetail = null,
		byte? PageBetweenItems = null,
		byte? PrintPrice = (byte)0,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			CustNumType _CustNumStarting = CustNumStarting;
			CustNumType _CustNumEnding = CustNumEnding;
			DateTimeType _AsOfDate = AsOfDate;
			DateOffsetType _AsOfDateOffset = AsOfDateOffset;
			ListYesNoType _ShowDetail = ShowDetail;
			ListYesNoType _PageBetweenItems = PageBetweenItems;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItembyCustomerSalesAnalysisSP";
				
				appDB.AddCommandParameter(cmd, "CustNumStarting", _CustNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumEnding", _CustNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDateOffset", _AsOfDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
