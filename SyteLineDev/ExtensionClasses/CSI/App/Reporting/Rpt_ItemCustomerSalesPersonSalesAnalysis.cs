//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemCustomerSalesPersonSalesAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemCustomerSalesPersonSalesAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemCustomerSalesPersonSalesAnalysisSp(string SalesPersonStarting = null,
		string SalesPersonEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? ExOptacAsOfDate = null,
		short? ExOptacAsOfDateOffset = null,
		byte? PageBetweenItems = null,
		byte? PrintPrice = (byte)0,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_ItemCustomerSalesPersonSalesAnalysis : IRpt_ItemCustomerSalesPersonSalesAnalysis
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemCustomerSalesPersonSalesAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemCustomerSalesPersonSalesAnalysisSp(string SalesPersonStarting = null,
		string SalesPersonEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? ExOptacAsOfDate = null,
		short? ExOptacAsOfDateOffset = null,
		byte? PageBetweenItems = null,
		byte? PrintPrice = (byte)0,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null)
		{
			SlsmanType _SalesPersonStarting = SalesPersonStarting;
			SlsmanType _SalesPersonEnding = SalesPersonEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateType _ExOptacAsOfDate = ExOptacAsOfDate;
			DateOffsetType _ExOptacAsOfDateOffset = ExOptacAsOfDateOffset;
			FlagNyType _PageBetweenItems = PageBetweenItems;
			FlagNyType _PrintPrice = PrintPrice;
			FlagNyType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemCustomerSalesPersonSalesAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "SalesPersonStarting", _SalesPersonStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesPersonEnding", _SalesPersonEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacAsOfDate", _ExOptacAsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacAsOfDateOffset", _ExOptacAsOfDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
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
