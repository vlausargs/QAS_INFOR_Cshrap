//PROJECT NAME: Production
//CLASS NAME: PsStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PsStat : IPsStat
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PsStat(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) PsStatSp(string PsFromStat,
		string PsToStat,
		string FromPsNum,
		string ToPsNum,
		string FromItem,
		string ToItem,
		DateTime? FromDate,
		DateTime? ToDate,
		int? PProcess,
		int? CopyPSItemBOM,
		int? CopyPSReleaseBOM,
		string Infobar,
		int? StartingDateOffset = null,
		int? EndingDateOffset = null)
		{
			PsStatusType _PsFromStat = PsFromStat;
			PsStatusType _PsToStat = PsToStat;
			PsNumType _FromPsNum = FromPsNum;
			PsNumType _ToPsNum = ToPsNum;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			DateType _FromDate = FromDate;
			DateType _ToDate = ToDate;
			ListYesNoType _PProcess = PProcess;
			ListYesNoType _CopyPSItemBOM = CopyPSItemBOM;
			ListYesNoType _CopyPSReleaseBOM = CopyPSReleaseBOM;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PsStatSp";
				
				appDB.AddCommandParameter(cmd, "PsFromStat", _PsFromStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsToStat", _PsToStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPsNum", _FromPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPsNum", _ToPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDate", _FromDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToDate", _ToDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyPSItemBOM", _CopyPSItemBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyPSReleaseBOM", _CopyPSReleaseBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
