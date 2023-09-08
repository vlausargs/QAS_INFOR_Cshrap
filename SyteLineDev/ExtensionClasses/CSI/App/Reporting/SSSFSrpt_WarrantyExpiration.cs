//PROJECT NAME: Reporting
//CLASS NAME: SSSFSrpt_WarrantyExpiration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSrpt_WarrantyExpiration : ISSSFSrpt_WarrantyExpiration
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSrpt_WarrantyExpiration(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSrpt_WarrantyExpirationSp(string beg_Item,
		string end_Item,
		string beg_ChildItem,
		string end_ChildItem,
		DateTime? beg_warr_expire,
		DateTime? end_warr_expire,
		int? IncludeSub,
		string pSite = null)
		{
			ItemType _beg_Item = beg_Item;
			ItemType _end_Item = end_Item;
			ItemType _beg_ChildItem = beg_ChildItem;
			ItemType _end_ChildItem = end_ChildItem;
			DateType _beg_warr_expire = beg_warr_expire;
			DateType _end_warr_expire = end_warr_expire;
			ListYesNoType _IncludeSub = IncludeSub;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSrpt_WarrantyExpirationSp";
				
				appDB.AddCommandParameter(cmd, "beg_Item", _beg_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_Item", _end_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_ChildItem", _beg_ChildItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_ChildItem", _end_ChildItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_warr_expire", _beg_warr_expire, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_warr_expire", _end_warr_expire, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSub", _IncludeSub, ParameterDirection.Input);
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
