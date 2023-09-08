//PROJECT NAME: Codes
//CLASS NAME: EFTMappedPivotFields.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class EFTMappedPivotFields : IEFTMappedPivotFields
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public EFTMappedPivotFields(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) EFTMappedPivotFieldsSp(string FileName,
		string ChildSequence,
		string Status,
		string RefType,
		string RefObject,
		string FilterString,
		string InfoBar)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				EFTFileNameType _FileName = FileName;
				StringType _ChildSequence = ChildSequence;
				EFTStatType _Status = Status;
				ReferenceType _RefType = RefType;
				ReferenceObjectType _RefObject = RefObject;
				VeryLongListType _FilterString = FilterString;
				InfobarType _InfoBar = InfoBar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "EFTMappedPivotFieldsSp";
					
					appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ChildSequence", _ChildSequence, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefObject", _RefObject, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
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
	}
}
