//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryConsignedFromVendorUsage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InventoryConsignedFromVendorUsage
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryConsignedFromVendorUsageSp(string PStartWarehouse = null,
		string PEndWarehouse = null,
		string PStartVendorNum = null,
		string PEndVendorNum = null,
		string PStartItem = null,
		string PEndItem = null,
		DateTime? PStartTranDate = null,
		DateTime? PEndTranDate = null,
		short? PStartTranDateOffset = null,
		short? PEndTranDateOffset = null,
		byte? PDisplayHeader = null,
		string pSite = null,
		byte? PrintItemOverview = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null);
	}
	
	public class Rpt_InventoryConsignedFromVendorUsage : IRpt_InventoryConsignedFromVendorUsage
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InventoryConsignedFromVendorUsage(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryConsignedFromVendorUsageSp(string PStartWarehouse = null,
		string PEndWarehouse = null,
		string PStartVendorNum = null,
		string PEndVendorNum = null,
		string PStartItem = null,
		string PEndItem = null,
		DateTime? PStartTranDate = null,
		DateTime? PEndTranDate = null,
		short? PStartTranDateOffset = null,
		short? PEndTranDateOffset = null,
		byte? PDisplayHeader = null,
		string pSite = null,
		byte? PrintItemOverview = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null)
		{
			WhseType _PStartWarehouse = PStartWarehouse;
			WhseType _PEndWarehouse = PEndWarehouse;
			VendNumType _PStartVendorNum = PStartVendorNum;
			VendNumType _PEndVendorNum = PEndVendorNum;
			ItemType _PStartItem = PStartItem;
			ItemType _PEndItem = PEndItem;
			DateTimeType _PStartTranDate = PStartTranDate;
			DateTimeType _PEndTranDate = PEndTranDate;
			DateOffsetType _PStartTranDateOffset = PStartTranDateOffset;
			DateOffsetType _PEndTranDateOffset = PEndTranDateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			DocumentNumType _DocumentNumStarting = DocumentNumStarting;
			DocumentNumType _DocumentNumEnding = DocumentNumEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InventoryConsignedFromVendorUsageSp";
				
				appDB.AddCommandParameter(cmd, "PStartWarehouse", _PStartWarehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndWarehouse", _PEndWarehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartVendorNum", _PStartVendorNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndVendorNum", _PEndVendorNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartItem", _PStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndItem", _PEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartTranDate", _PStartTranDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTranDate", _PEndTranDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartTranDateOffset", _PStartTranDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTranDateOffset", _PEndTranDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumStarting", _DocumentNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumEnding", _DocumentNumEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
