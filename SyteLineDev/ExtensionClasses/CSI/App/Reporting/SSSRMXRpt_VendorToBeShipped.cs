//PROJECT NAME: Reporting
//CLASS NAME: SSSRMXRpt_VendorToBeShipped.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSRMXRpt_VendorToBeShipped : ISSSRMXRpt_VendorToBeShipped
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRMXRpt_VendorToBeShipped(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRMXRpt_VendorToBeShippedSp(string StartVendNum = null,
		string EndVendNum = null,
		string StartItem = null,
		string EndItem = null,
		string StartRefNum = null,
		string EndRefNum = null,
		int? InclPO = 1,
		int? InclRMA = 1,
		string pSite = null)
		{
			VendNumType _StartVendNum = StartVendNum;
			VendNumType _EndVendNum = EndVendNum;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			RMXRefNumType _StartRefNum = StartRefNum;
			RMXRefNumType _EndRefNum = EndRefNum;
			ListYesNoType _InclPO = InclPO;
			ListYesNoType _InclRMA = InclRMA;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXRpt_VendorToBeShippedSp";
				
				appDB.AddCommandParameter(cmd, "StartVendNum", _StartVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRefNum", _StartRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRefNum", _EndRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclPO", _InclPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclRMA", _InclRMA, ParameterDirection.Input);
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
