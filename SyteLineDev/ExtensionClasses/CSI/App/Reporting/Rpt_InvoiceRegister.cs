//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceRegister.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InvoiceRegister
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceRegisterSp(string InvNumStarting = null,
		string InvNumEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string StateStarting = null,
		string StateEnding = null,
		byte? InvoiceSourceOrder = null,
		byte? InvoiceSourceAR = null,
		byte? ShowDetail = null,
		byte? PrintTaxCodeSummary = null,
		byte? TranslateToDomesticCurrency = null,
		short? InvoiceDateStartingOffset = null,
		short? InvoiceDateEndingOffset = null,
		byte? ShowCost = null,
		byte? ShowPrice = null,
		byte? DisplayHeader = null,
		byte? SSSFSInclSRO = null,
		byte? SSSFSInclContract = null,
		int? TaskId = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_InvoiceRegister : IRpt_InvoiceRegister
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InvoiceRegister(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceRegisterSp(string InvNumStarting = null,
		string InvNumEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string StateStarting = null,
		string StateEnding = null,
		byte? InvoiceSourceOrder = null,
		byte? InvoiceSourceAR = null,
		byte? ShowDetail = null,
		byte? PrintTaxCodeSummary = null,
		byte? TranslateToDomesticCurrency = null,
		short? InvoiceDateStartingOffset = null,
		short? InvoiceDateEndingOffset = null,
		byte? ShowCost = null,
		byte? ShowPrice = null,
		byte? DisplayHeader = null,
		byte? SSSFSInclSRO = null,
		byte? SSSFSInclContract = null,
		int? TaskId = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null)
		{
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			GenericDateType _InvoiceDateStarting = InvoiceDateStarting;
			GenericDateType _InvoiceDateEnding = InvoiceDateEnding;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			StateType _StateStarting = StateStarting;
			StateType _StateEnding = StateEnding;
			ListYesNoType _InvoiceSourceOrder = InvoiceSourceOrder;
			ListYesNoType _InvoiceSourceAR = InvoiceSourceAR;
			ListYesNoType _ShowDetail = ShowDetail;
			ListYesNoType _PrintTaxCodeSummary = PrintTaxCodeSummary;
			ListYesNoType _TranslateToDomesticCurrency = TranslateToDomesticCurrency;
			DateOffsetType _InvoiceDateStartingOffset = InvoiceDateStartingOffset;
			DateOffsetType _InvoiceDateEndingOffset = InvoiceDateEndingOffset;
			ListYesNoType _ShowCost = ShowCost;
			ListYesNoType _ShowPrice = ShowPrice;
			ListYesNoType _DisplayHeader = DisplayHeader;
			FlagNyType _SSSFSInclSRO = SSSFSInclSRO;
			FlagNyType _SSSFSInclContract = SSSFSInclContract;
			TaskNumType _TaskId = TaskId;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InvoiceRegisterSp";
				
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
				appDB.AddCommandParameter(cmd, "InvoiceSourceOrder", _InvoiceSourceOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceSourceAR", _InvoiceSourceAR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTaxCodeSummary", _PrintTaxCodeSummary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranslateToDomesticCurrency", _TranslateToDomesticCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStartingOffset", _InvoiceDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEndingOffset", _InvoiceDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowCost", _ShowCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPrice", _ShowPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSInclSRO", _SSSFSInclSRO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSSFSInclContract", _SSSFSInclContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
