//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryConsignedtoCustomer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_InventoryConsignedtoCustomer : IRpt_InventoryConsignedtoCustomer
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InventoryConsignedtoCustomer(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryConsignedtoCustomerSp(string WhseStaring = null,
		string WhseEnding = null,
		string CustStarting = null,
		string CustEnding = null,
		int? CustSeqStarting = null,
		int? CustSeqEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string SortBy = "C",
		int? DisplayHeader = 0,
		string pSite = null)
		{
			WhseType _WhseStaring = WhseStaring;
			WhseType _WhseEnding = WhseEnding;
			CustNumType _CustStarting = CustStarting;
			CustNumType _CustEnding = CustEnding;
			CustSeqType _CustSeqStarting = CustSeqStarting;
			CustSeqType _CustSeqEnding = CustSeqEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			StringType _SortBy = SortBy;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InventoryConsignedtoCustomerSp";
				
				appDB.AddCommandParameter(cmd, "WhseStaring", _WhseStaring, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustStarting", _CustStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustEnding", _CustEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeqStarting", _CustSeqStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeqEnding", _CustSeqEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
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
