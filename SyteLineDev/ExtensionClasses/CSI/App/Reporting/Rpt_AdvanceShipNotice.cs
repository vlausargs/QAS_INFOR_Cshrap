//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AdvanceShipNotice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_AdvanceShipNotice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_AdvanceShipNoticeSp(string StartCustNum = null,
		string EndCustNum = null,
		int? StartCustSeq = null,
		int? EndCustSeq = null,
		string StartDoNum = null,
		string EndDoNum = null,
		decimal? StartShipmentID = null,
		decimal? EndShipmentID = null,
		byte? DisplayHeader = null,
		string PrintType = null,
		byte? PrintSwitchFlag = null,
		int? TaskId = null,
		string pSite = null);
	}
	
	public class Rpt_AdvanceShipNotice : IRpt_AdvanceShipNotice
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_AdvanceShipNotice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_AdvanceShipNoticeSp(string StartCustNum = null,
		string EndCustNum = null,
		int? StartCustSeq = null,
		int? EndCustSeq = null,
		string StartDoNum = null,
		string EndDoNum = null,
		decimal? StartShipmentID = null,
		decimal? EndShipmentID = null,
		byte? DisplayHeader = null,
		string PrintType = null,
		byte? PrintSwitchFlag = null,
		int? TaskId = null,
		string pSite = null)
		{
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			CustSeqType _StartCustSeq = StartCustSeq;
			CustSeqType _EndCustSeq = EndCustSeq;
			DoNumType _StartDoNum = StartDoNum;
			DoNumType _EndDoNum = EndDoNum;
			ShipmentIDType _StartShipmentID = StartShipmentID;
			ShipmentIDType _EndShipmentID = EndShipmentID;
			ListYesNoType _DisplayHeader = DisplayHeader;
			PrintModeType _PrintType = PrintType;
			ListYesNoType _PrintSwitchFlag = PrintSwitchFlag;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_AdvanceShipNoticeSp";
				
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustSeq", _StartCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustSeq", _EndCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDoNum", _StartDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDoNum", _EndDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartShipmentID", _StartShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShipmentID", _EndShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintType", _PrintType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSwitchFlag", _PrintSwitchFlag, ParameterDirection.Input);
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
