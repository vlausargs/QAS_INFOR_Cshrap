//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemSerialNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemSerialNumber
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemSerialNumberSp(string SSerial = null,
		string ESerial = null,
		string SItem = null,
		string EItem = null,
		string SLot = null,
		string ELot = null,
		string CustStarting = null,
		string CustENDing = null,
		byte? DisplayHeader = null,
		string DisplaySource = null,
		string DisplayDestination = null,
		int? TaskId = null,
		string BGSessionId = null,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null);
	}
	
	public class Rpt_ItemSerialNumber : IRpt_ItemSerialNumber
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemSerialNumber(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemSerialNumberSp(string SSerial = null,
		string ESerial = null,
		string SItem = null,
		string EItem = null,
		string SLot = null,
		string ELot = null,
		string CustStarting = null,
		string CustENDing = null,
		byte? DisplayHeader = null,
		string DisplaySource = null,
		string DisplayDestination = null,
		int? TaskId = null,
		string BGSessionId = null,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null)
		{
			SerNumType _SSerial = SSerial;
			SerNumType _ESerial = ESerial;
			ItemType _SItem = SItem;
			ItemType _EItem = EItem;
			LotType _SLot = SLot;
			LotType _ELot = ELot;
			CustNumType _CustStarting = CustStarting;
			CustNumType _CustENDing = CustENDing;
			ListYesNoType _DisplayHeader = DisplayHeader;
			InfobarType _DisplaySource = DisplaySource;
			InfobarType _DisplayDestination = DisplayDestination;
			TaskNumType _TaskId = TaskId;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			DocumentNumType _DocumentNumStarting = DocumentNumStarting;
			DocumentNumType _DocumentNumEnding = DocumentNumEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemSerialNumberSp";
				
				appDB.AddCommandParameter(cmd, "SSerial", _SSerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ESerial", _ESerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SItem", _SItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EItem", _EItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLot", _SLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELot", _ELot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustStarting", _CustStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustENDing", _CustENDing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplaySource", _DisplaySource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayDestination", _DisplayDestination, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
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
