//PROJECT NAME: CSIReport
//CLASS NAME: FloorStkReplenCel06RP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IFloorStkReplenCel06RP
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FloorStkReplenCel06RPSp(string pStartJob,
		string pEndJob,
		short? pStartJobSuffix,
		short? pEndJobSuffix,
		string pStartPsNum,
		string pEndPsNum,
		string pStartItem,
		string pEndItem,
		string pStartJobMatlItem,
		string pEndJobMatlItem,
		DateTime? pStartDate,
		DateTime? pEndDate,
		string pStartWc,
		string pEndWc,
		byte? pSubtractFlrQty,
		string pPostMat,
		string pWhse,
		byte? pBarCode,
		string pConsolidateBy,
		byte? pDisplayReportHeader,
		string Infobar,
		string pSite = null);
	}
	
	public class FloorStkReplenCel06RP : IFloorStkReplenCel06RP
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public FloorStkReplenCel06RP(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) FloorStkReplenCel06RPSp(string pStartJob,
		string pEndJob,
		short? pStartJobSuffix,
		short? pEndJobSuffix,
		string pStartPsNum,
		string pEndPsNum,
		string pStartItem,
		string pEndItem,
		string pStartJobMatlItem,
		string pEndJobMatlItem,
		DateTime? pStartDate,
		DateTime? pEndDate,
		string pStartWc,
		string pEndWc,
		byte? pSubtractFlrQty,
		string pPostMat,
		string pWhse,
		byte? pBarCode,
		string pConsolidateBy,
		byte? pDisplayReportHeader,
		string Infobar,
		string pSite = null)
		{
			JobType _pStartJob = pStartJob;
			JobType _pEndJob = pEndJob;
			SuffixType _pStartJobSuffix = pStartJobSuffix;
			SuffixType _pEndJobSuffix = pEndJobSuffix;
			PsNumType _pStartPsNum = pStartPsNum;
			PsNumType _pEndPsNum = pEndPsNum;
			ItemType _pStartItem = pStartItem;
			ItemType _pEndItem = pEndItem;
			ItemType _pStartJobMatlItem = pStartJobMatlItem;
			ItemType _pEndJobMatlItem = pEndJobMatlItem;
			DateType _pStartDate = pStartDate;
			DateType _pEndDate = pEndDate;
			WcType _pStartWc = pStartWc;
			WcType _pEndWc = pEndWc;
			FlagNyType _pSubtractFlrQty = pSubtractFlrQty;
			LongListType _pPostMat = pPostMat;
			WhseType _pWhse = pWhse;
			FlagNyType _pBarCode = pBarCode;
			StringType _pConsolidateBy = pConsolidateBy;
			FlagNyType _pDisplayReportHeader = pDisplayReportHeader;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FloorStkReplenCel06RPSp";
				
				appDB.AddCommandParameter(cmd, "pStartJob", _pStartJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndJob", _pEndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartJobSuffix", _pStartJobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndJobSuffix", _pEndJobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPsNum", _pStartPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPsNum", _pEndPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartJobMatlItem", _pStartJobMatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndJobMatlItem", _pEndJobMatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDate", _pStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDate", _pEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartWc", _pStartWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndWc", _pEndWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSubtractFlrQty", _pSubtractFlrQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostMat", _pPostMat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWhse", _pWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBarCode", _pBarCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConsolidateBy", _pConsolidateBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDisplayReportHeader", _pDisplayReportHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
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
