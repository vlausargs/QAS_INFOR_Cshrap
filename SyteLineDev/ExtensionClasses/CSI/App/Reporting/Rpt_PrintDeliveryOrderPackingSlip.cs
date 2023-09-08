//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintDeliveryOrderPackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PrintDeliveryOrderPackingSlip : IRpt_PrintDeliveryOrderPackingSlip
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PrintDeliveryOrderPackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintDeliveryOrderPackingSlipSp(string StartingDo = null,
		string EndingDo = null,
		int? PrPickupDate = null,
		int? PrDoSeqText = null,
		int? PrDoLineText = null,
		int? PrDoText = null,
		int? PageByDoLine = null,
		int? PrSerialNumbers = null,
		string StatingCust = null,
		string EndingCust = null,
		int? StatingShipTo = null,
		int? EndingShipTo = null,
		DateTime? StatingPickupDate = null,
		DateTime? EndingPickupDate = null,
		int? StatingPickupDateOffset = null,
		int? EndingPickupDateOffset = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? PrintItemOverview = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			DoNumType _StartingDo = StartingDo;
			DoNumType _EndingDo = EndingDo;
			FlagNyType _PrPickupDate = PrPickupDate;
			FlagNyType _PrDoSeqText = PrDoSeqText;
			FlagNyType _PrDoLineText = PrDoLineText;
			FlagNyType _PrDoText = PrDoText;
			FlagNyType _PageByDoLine = PageByDoLine;
			FlagNyType _PrSerialNumbers = PrSerialNumbers;
			CustNumType _StatingCust = StatingCust;
			CustNumType _EndingCust = EndingCust;
			CustSeqType _StatingShipTo = StatingShipTo;
			CustSeqType _EndingShipTo = EndingShipTo;
			DateType _StatingPickupDate = StatingPickupDate;
			DateType _EndingPickupDate = EndingPickupDate;
			DateOffsetType _StatingPickupDateOffset = StatingPickupDateOffset;
			DateOffsetType _EndingPickupDateOffset = EndingPickupDateOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _PrintItemOverview = PrintItemOverview;
			FlagNyType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PrintDeliveryOrderPackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "StartingDo", _StartingDo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDo", _EndingDo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrPickupDate", _PrPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrDoSeqText", _PrDoSeqText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrDoLineText", _PrDoLineText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrDoText", _PrDoText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageByDoLine", _PageByDoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrSerialNumbers", _PrSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatingCust", _StatingCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCust", _EndingCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatingShipTo", _StatingShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingShipTo", _EndingShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatingPickupDate", _StatingPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPickupDate", _EndingPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatingPickupDateOffset", _StatingPickupDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPickupDateOffset", _EndingPickupDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
