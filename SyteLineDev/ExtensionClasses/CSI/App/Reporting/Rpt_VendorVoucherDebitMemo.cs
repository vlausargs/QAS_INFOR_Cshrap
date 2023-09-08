//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VendorVoucherDebitMemo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VendorVoucherDebitMemo : IRpt_VendorVoucherDebitMemo
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VendorVoucherDebitMemo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VendorVoucherDebitMemoSp(int? DetailPurchaseOrder = 0,
		int? DetailItem = 0,
		int? DetailVendorItem = 0,
		int? VendorProfileUseProfile = 0,
		string VendorStarting = null,
		string VendorEnding = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		string PoNumStarting = null,
		string PoNumEnding = null,
		string InvNumStarting = null,
		string InvNumEnding = null,
		DateTime? VoucherDateStarting = null,
		DateTime? VoucherDateEnding = null,
		int? VoucherDateStartingOffset = null,
		int? VoucherDateEndingOffset = null,
		int? VoucherDateIncrement = 0,
		int? DisplayHeader = 0,
		int? ShowInternal = 0,
		int? ShowExternal = 0,
		int? PrintItemOverview = 0,
		int? TaskID = null,
		string BGSessionId = null,
		string pSite = null)
		{
			ListYesNoType _DetailPurchaseOrder = DetailPurchaseOrder;
			ListYesNoType _DetailItem = DetailItem;
			ListYesNoType _DetailVendorItem = DetailVendorItem;
			ListYesNoType _VendorProfileUseProfile = VendorProfileUseProfile;
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			VoucherType _VoucherStarting = VoucherStarting;
			VoucherType _VoucherEnding = VoucherEnding;
			PoNumType _PoNumStarting = PoNumStarting;
			PoNumType _PoNumEnding = PoNumEnding;
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			DateType _VoucherDateStarting = VoucherDateStarting;
			DateType _VoucherDateEnding = VoucherDateEnding;
			DateOffsetType _VoucherDateStartingOffset = VoucherDateStartingOffset;
			DateOffsetType _VoucherDateEndingOffset = VoucherDateEndingOffset;
			ListYesNoType _VoucherDateIncrement = VoucherDateIncrement;
			ListYesNoType _DisplayHeader = DisplayHeader;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			TaskNumType _TaskID = TaskID;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VendorVoucherDebitMemoSp";
				
				appDB.AddCommandParameter(cmd, "DetailPurchaseOrder", _DetailPurchaseOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DetailItem", _DetailItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DetailVendorItem", _DetailVendorItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorProfileUseProfile", _VendorProfileUseProfile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherStarting", _VoucherStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherEnding", _VoucherEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNumStarting", _PoNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNumEnding", _PoNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateStarting", _VoucherDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateEnding", _VoucherDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateStartingOffset", _VoucherDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateEndingOffset", _VoucherDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateIncrement", _VoucherDateIncrement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
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
