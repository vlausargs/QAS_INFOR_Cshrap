//PROJECT NAME: Reporting
//CLASS NAME: SSSRFQRpt_SendQuoteByVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ISSSRFQRpt_SendQuoteByVendor
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRFQRpt_SendQuoteByVendorSp(string VendNum,
		string StartingRFQ,
		string EndingRFQ,
		string StartingProdCode,
		string EndingProdCode,
		string StartingItem,
		string EndingItem,
		string DistMethod,
		string SelectedRfqNumLine,
		byte? PageBreak,
		byte? Preview,
		string pSite = null);
	}
	
	public class SSSRFQRpt_SendQuoteByVendor : ISSSRFQRpt_SendQuoteByVendor
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRFQRpt_SendQuoteByVendor(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRFQRpt_SendQuoteByVendorSp(string VendNum,
		string StartingRFQ,
		string EndingRFQ,
		string StartingProdCode,
		string EndingProdCode,
		string StartingItem,
		string EndingItem,
		string DistMethod,
		string SelectedRfqNumLine,
		byte? PageBreak,
		byte? Preview,
		string pSite = null)
		{
			VendNumType _VendNum = VendNum;
			RFQNumType _StartingRFQ = StartingRFQ;
			RFQNumType _EndingRFQ = EndingRFQ;
			ProductCodeType _StartingProdCode = StartingProdCode;
			ProductCodeType _EndingProdCode = EndingProdCode;
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			RFQDistMethodType _DistMethod = DistMethod;
			LongListType _SelectedRfqNumLine = SelectedRfqNumLine;
			ListYesNoType _PageBreak = PageBreak;
			ListYesNoType _Preview = Preview;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQRpt_SendQuoteByVendorSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingRFQ", _StartingRFQ, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingRFQ", _EndingRFQ, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingProdCode", _StartingProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProdCode", _EndingProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistMethod", _DistMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectedRfqNumLine", _SelectedRfqNumLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBreak", _PageBreak, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Preview", _Preview, ParameterDirection.Input);
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
