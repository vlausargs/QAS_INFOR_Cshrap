//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShipmentProFormaInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ShipmentProFormaInvoice : IRpt_ShipmentProFormaInvoice
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ShipmentProFormaInvoice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShipmentProFormaInvoiceSp(int? PrintBlankPickupDate = null,
		int? PrintShipmentSequenceText = null,
		int? IncludeSerialNumbers = null,
		decimal? ShipmentStarting = null,
		decimal? ShipmentEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? ShipToStarting = null,
		int? ShipToEnding = null,
		DateTime? PickupDateStarting = null,
		DateTime? PickupDateEnding = null,
		int? DateStartingOffset = null,
		int? DateENDingOffset = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			FlagNyType _PrintBlankPickupDate = PrintBlankPickupDate;
			FlagNyType _PrintShipmentSequenceText = PrintShipmentSequenceText;
			FlagNyType _IncludeSerialNumbers = IncludeSerialNumbers;
			ShipmentIDType _ShipmentStarting = ShipmentStarting;
			ShipmentIDType _ShipmentEnding = ShipmentEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			CustSeqType _ShipToStarting = ShipToStarting;
			CustSeqType _ShipToEnding = ShipToEnding;
			DateType _PickupDateStarting = PickupDateStarting;
			DateType _PickupDateEnding = PickupDateEnding;
			DateOffsetType _DateStartingOffset = DateStartingOffset;
			DateOffsetType _DateENDingOffset = DateENDingOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ShipmentProFormaInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "PrintBlankPickupDate", _PrintBlankPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintShipmentSequenceText", _PrintShipmentSequenceText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSerialNumbers", _IncludeSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentStarting", _ShipmentStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentEnding", _ShipmentEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToStarting", _ShipToStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToEnding", _ShipToEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateStarting", _PickupDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateEnding", _PickupDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffset", _DateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateENDingOffset", _DateENDingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
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
