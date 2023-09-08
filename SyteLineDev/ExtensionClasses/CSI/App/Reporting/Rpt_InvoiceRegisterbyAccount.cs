//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceRegisterbyAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_InvoiceRegisterbyAccount : IRpt_InvoiceRegisterbyAccount
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InvoiceRegisterbyAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceRegisterbyAccountSp(string AccountStarting,
		string AccountEnding,
		string InvNumStarting,
		string InvNumEnding,
		DateTime? InvoiceDateStarting,
		DateTime? InvoiceDateEnding,
		string OrderStarting,
		string OrderEnding,
		string CustomerStarting,
		string CustomerEnding,
		string StateStarting,
		string StateEnding,
		string ItemStarting,
		string ItemEnding,
		string InvoiceSourceOrder,
		string InvoiceSourceAR,
		int? TranslateToDomesticCurrency,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? ShowPrice = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		int? SSSFSIncludeSourceSRO = null,
		int? SSSFSIncludeSourceContract = null,
		string SSSFSSROStarting = null,
		string SSSFSSROEnding = null,
		string SSSFSContractStarting = null,
		string SSSFSContractEnding = null,
		string BGSessionId = null,
		string pSite = null)
		{
			HighLowCharType _AccountStarting = AccountStarting;
			HighLowCharType _AccountEnding = AccountEnding;
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			DateType _InvoiceDateStarting = InvoiceDateStarting;
			DateType _InvoiceDateEnding = InvoiceDateEnding;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			StateType _StateStarting = StateStarting;
			StateType _StateEnding = StateEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			StringType _InvoiceSourceOrder = InvoiceSourceOrder;
			StringType _InvoiceSourceAR = InvoiceSourceAR;
			FlagNyType _TranslateToDomesticCurrency = TranslateToDomesticCurrency;
			DateOffsetType _InvoiceDateStartingOffset = InvoiceDateStartingOffset;
			DateOffsetType _InvoiceDateEndingOffset = InvoiceDateEndingOffset;
			FlagNyType _ShowPrice = ShowPrice;
			FlagNyType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			FlagNyType _SSSFSIncludeSourceSRO = SSSFSIncludeSourceSRO;
			FlagNyType _SSSFSIncludeSourceContract = SSSFSIncludeSourceContract;
			HighLowCharType _SSSFSSROStarting = SSSFSSROStarting;
			HighLowCharType _SSSFSSROEnding = SSSFSSROEnding;
			HighLowCharType _SSSFSContractStarting = SSSFSContractStarting;
			HighLowCharType _SSSFSContractEnding = SSSFSContractEnding;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InvoiceRegisterbyAccountSp";
				
				appDB.AddCommandParameter(cmd, "AccountStarting", _AccountStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountEnding", _AccountEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStarting", _InvoiceDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEnding", _InvoiceDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StateStarting", _StateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StateEnding", _StateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceSourceOrder", _InvoiceSourceOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceSourceAR", _InvoiceSourceAR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranslateToDomesticCurrency", _TranslateToDomesticCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStartingOffset", _InvoiceDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEndingOffset", _InvoiceDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPrice", _ShowPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSIncludeSourceSRO", _SSSFSIncludeSourceSRO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSIncludeSourceContract", _SSSFSIncludeSourceContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSSROStarting", _SSSFSSROStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSSROEnding", _SSSFSSROEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSContractStarting", _SSSFSContractStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSContractEnding", _SSSFSContractEnding, ParameterDirection.Input);
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
