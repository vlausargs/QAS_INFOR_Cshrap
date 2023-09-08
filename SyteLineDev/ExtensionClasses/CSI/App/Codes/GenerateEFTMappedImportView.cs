//PROJECT NAME: Codes
//CLASS NAME: GenerateEFTMappedImportView.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Codes
{
	public class GenerateEFTMappedImportView : IGenerateEFTMappedImportView
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public GenerateEFTMappedImportView(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) GenerateEFTMappedImportViewSp(string FileName,
		string MapId,
		string ReturnType,
		decimal? ImportSequence,
		string InfoBar)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
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
					cmd.CommandText = "GenerateEFTMappedImportViewSp";
					
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
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}

		public ICollectionLoadResponse GenerateEFTMappedImportViewFn(
			string FileName,
			string MapID,
			string ReturnFormat)
		{
			OSLocationType _FileName = FileName;
			EFTMappingIdType _MapID = MapID;
			StringType _ReturnFormat = ReturnFormat;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[GenerateEFTMappedImportView](@FileName, @MapID, @ReturnFormat)";

				appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MapID", _MapID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnFormat", _ReturnFormat, ParameterDirection.Input);

				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GenerateEFTMappedImportView";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
