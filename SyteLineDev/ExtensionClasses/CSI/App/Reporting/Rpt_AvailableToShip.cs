//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AvailableToShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_AvailableToShip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_AvailableToShipSp(string pCoType = null,
		string pCoStat = null,
		int? pBatchID = null,
		byte? pOverwriteBatch = null,
		string pCoitemStat = null,
		string pSortBy = null,
		string pStartCoNum = null,
		string pEndCoNum = null,
		string pStartCustNum = null,
		string pEndCustNum = null,
		string pStartItem = null,
		string pEndItem = null,
		string pStartWhse = null,
		string pEndWhse = null,
		byte? PrintPrice = (byte)0,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		byte? IncludeShipEarly = null,
		DateTime? CutoffDate = null,
		string pSite = null,
		string BGUser = null,
		byte? IncludeShipHold = null);
	}
	
	public class Rpt_AvailableToShip : IRpt_AvailableToShip
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_AvailableToShip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_AvailableToShipSp(string pCoType = null,
		string pCoStat = null,
		int? pBatchID = null,
		byte? pOverwriteBatch = null,
		string pCoitemStat = null,
		string pSortBy = null,
		string pStartCoNum = null,
		string pEndCoNum = null,
		string pStartCustNum = null,
		string pEndCustNum = null,
		string pStartItem = null,
		string pEndItem = null,
		string pStartWhse = null,
		string pEndWhse = null,
		byte? PrintPrice = (byte)0,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		byte? IncludeShipEarly = null,
		DateTime? CutoffDate = null,
		string pSite = null,
		string BGUser = null,
		byte? IncludeShipHold = null)
		{
			InfobarType _pCoType = pCoType;
			InfobarType _pCoStat = pCoStat;
			BatchIdType _pBatchID = pBatchID;
			ListYesNoType _pOverwriteBatch = pOverwriteBatch;
			InfobarType _pCoitemStat = pCoitemStat;
			StringType _pSortBy = pSortBy;
			CoNumType _pStartCoNum = pStartCoNum;
			CoNumType _pEndCoNum = pEndCoNum;
			CustNumType _pStartCustNum = pStartCustNum;
			CustNumType _pEndCustNum = pEndCustNum;
			ItemType _pStartItem = pStartItem;
			ItemType _pEndItem = pEndItem;
			WhseType _pStartWhse = pStartWhse;
			WhseType _pEndWhse = pEndWhse;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			ListYesNoType _IncludeShipEarly = IncludeShipEarly;
			DateType _CutoffDate = CutoffDate;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			ListYesNoType _IncludeShipHold = IncludeShipHold;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_AvailableToShipSp";
				
				appDB.AddCommandParameter(cmd, "pCoType", _pCoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoStat", _pCoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBatchID", _pBatchID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOverwriteBatch", _pOverwriteBatch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoitemStat", _pCoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSortBy", _pSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCoNum", _pStartCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCoNum", _pEndCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCustNum", _pStartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum", _pEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartWhse", _pStartWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndWhse", _pEndWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeShipEarly", _IncludeShipEarly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeShipHold", _IncludeShipHold, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
