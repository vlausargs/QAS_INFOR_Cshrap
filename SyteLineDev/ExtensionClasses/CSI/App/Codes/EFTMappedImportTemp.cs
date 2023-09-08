//PROJECT NAME: Codes
//CLASS NAME: EFTMappedImportTemp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class EFTMappedImportTemp : IEFTMappedImportTemp
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public EFTMappedImportTemp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) EFTMappedImportTempSp(string FileName,
		string MapId,
		string ReturnType,
		decimal? ImportSequence,
		string InfoBar)
		{
			OSLocationType _FileName = FileName;
			EFTMappingIdType _MapId = MapId;
			StringType _ReturnType = ReturnType;
			SequenceType _ImportSequence = ImportSequence;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTMappedImportTempSp";
				
				appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MapId", _MapId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnType", _ReturnType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportSequence", _ImportSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, InfoBar);
			}
		}
	}
}
