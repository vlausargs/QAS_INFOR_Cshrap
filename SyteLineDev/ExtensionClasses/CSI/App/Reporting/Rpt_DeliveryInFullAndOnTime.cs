//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DeliveryInFullAndOnTime.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_DeliveryInFullAndOnTime
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_DeliveryInFullAndOnTimeSp(string PCustomerStarting = null,
		string PCustomerEnding = null,
		string POrderStarting = null,
		string POrderEnding = null,
		string PProductCodeStarting = null,
		string PProductCodeEnding = null,
		string PItemStarting = null,
		string PItemEnding = null,
		DateTime? PLastShipDateStarting = null,
		DateTime? PLastShipDateEnding = null,
		short? PLastShipDateStartingOffset = null,
		short? PLastShipDateEndingOffset = null,
		DateTime? PDueDateStarting = null,
		DateTime? PDueDateEnding = null,
		short? PDueDateStartingOffset = null,
		short? PDueDateEndingOffset = null,
		DateTime? POrderDateStarting = null,
		DateTime? POrderDateEnding = null,
		short? POrderDateStartingOffset = null,
		short? POrderDateEndingOffset = null,
		string PSummary = null,
		string PCOItemStatus = null,
		int? PSuccess = null,
		int? PFail = null,
		string PSiteGroup = null,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
	
	public class Rpt_DeliveryInFullAndOnTime : IRpt_DeliveryInFullAndOnTime
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_DeliveryInFullAndOnTime(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_DeliveryInFullAndOnTimeSp(string PCustomerStarting = null,
		string PCustomerEnding = null,
		string POrderStarting = null,
		string POrderEnding = null,
		string PProductCodeStarting = null,
		string PProductCodeEnding = null,
		string PItemStarting = null,
		string PItemEnding = null,
		DateTime? PLastShipDateStarting = null,
		DateTime? PLastShipDateEnding = null,
		short? PLastShipDateStartingOffset = null,
		short? PLastShipDateEndingOffset = null,
		DateTime? PDueDateStarting = null,
		DateTime? PDueDateEnding = null,
		short? PDueDateStartingOffset = null,
		short? PDueDateEndingOffset = null,
		DateTime? POrderDateStarting = null,
		DateTime? POrderDateEnding = null,
		short? POrderDateStartingOffset = null,
		short? POrderDateEndingOffset = null,
		string PSummary = null,
		string PCOItemStatus = null,
		int? PSuccess = null,
		int? PFail = null,
		string PSiteGroup = null,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			CustNumType _PCustomerStarting = PCustomerStarting;
			CustNumType _PCustomerEnding = PCustomerEnding;
			CoNumType _POrderStarting = POrderStarting;
			CoNumType _POrderEnding = POrderEnding;
			ProductCodeType _PProductCodeStarting = PProductCodeStarting;
			ProductCodeType _PProductCodeEnding = PProductCodeEnding;
			ItemType _PItemStarting = PItemStarting;
			ItemType _PItemEnding = PItemEnding;
			DateType _PLastShipDateStarting = PLastShipDateStarting;
			DateType _PLastShipDateEnding = PLastShipDateEnding;
			DateOffsetType _PLastShipDateStartingOffset = PLastShipDateStartingOffset;
			DateOffsetType _PLastShipDateEndingOffset = PLastShipDateEndingOffset;
			DateType _PDueDateStarting = PDueDateStarting;
			DateType _PDueDateEnding = PDueDateEnding;
			DateOffsetType _PDueDateStartingOffset = PDueDateStartingOffset;
			DateOffsetType _PDueDateEndingOffset = PDueDateEndingOffset;
			DateType _POrderDateStarting = POrderDateStarting;
			DateType _POrderDateEnding = POrderDateEnding;
			DateOffsetType _POrderDateStartingOffset = POrderDateStartingOffset;
			DateOffsetType _POrderDateEndingOffset = POrderDateEndingOffset;
			StringType _PSummary = PSummary;
			StringType _PCOItemStatus = PCOItemStatus;
			IntType _PSuccess = PSuccess;
			IntType _PFail = PFail;
			SiteGroupType _PSiteGroup = PSiteGroup;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_DeliveryInFullAndOnTimeSp";
				
				appDB.AddCommandParameter(cmd, "PCustomerStarting", _PCustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustomerEnding", _PCustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderStarting", _POrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderEnding", _POrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProductCodeStarting", _PProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProductCodeEnding", _PProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemStarting", _PItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemEnding", _PItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastShipDateStarting", _PLastShipDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastShipDateEnding", _PLastShipDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastShipDateStartingOffset", _PLastShipDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastShipDateEndingOffset", _PLastShipDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDateStarting", _PDueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDateEnding", _PDueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDateStartingOffset", _PDueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDateEndingOffset", _PDueDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderDateStarting", _POrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderDateEnding", _POrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderDateStartingOffset", _POrderDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderDateEndingOffset", _POrderDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSummary", _PSummary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCOItemStatus", _PCOItemStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuccess", _PSuccess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFail", _PFail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);
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
