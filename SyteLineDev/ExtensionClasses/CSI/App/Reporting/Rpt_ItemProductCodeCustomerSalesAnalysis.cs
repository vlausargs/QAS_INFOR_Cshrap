//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemProductCodeCustomerSalesAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemProductCodeCustomerSalesAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemProductCodeCustomerSalesAnalysisSp(string CustomerStarting = null,
		string CustomerEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? TransDateStarting = null,
		short? TransDateStartingOffset = null,
		DateTime? TransDateEnding = null,
		short? TransDateEndingOffset = null,
		byte? SumCorpCust = (byte)0,
		byte? PrintPrice = (byte)0,
		string SiteGroup = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_ItemProductCodeCustomerSalesAnalysis : IRpt_ItemProductCodeCustomerSalesAnalysis
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemProductCodeCustomerSalesAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemProductCodeCustomerSalesAnalysisSp(string CustomerStarting = null,
		string CustomerEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? TransDateStarting = null,
		short? TransDateStartingOffset = null,
		DateTime? TransDateEnding = null,
		short? TransDateEndingOffset = null,
		byte? SumCorpCust = (byte)0,
		byte? PrintPrice = (byte)0,
		string SiteGroup = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			DateType _TransDateStarting = TransDateStarting;
			DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
			DateType _TransDateEnding = TransDateEnding;
			DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
			ListYesNoType _SumCorpCust = SumCorpCust;
			ListYesNoType _PrintPrice = PrintPrice;
			SiteGroupType _SiteGroup = SiteGroup;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemProductCodeCustomerSalesAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SumCorpCust", _SumCorpCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
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
