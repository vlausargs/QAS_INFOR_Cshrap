//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedTeamLoadConflict.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedTeamLoadConflict : ISSSFSSchedTeamLoadConflict
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSSchedTeamLoadConflict(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSFSSchedTeamLoadConflictSp(string PartnerId,
		string SchedDate,
		string Hrs,
		string NewApptRowPtr,
		string NewApptRowNum,
		string Infobar,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _PartnerId = PartnerId;
				StringType _SchedDate = SchedDate;
				StringType _Hrs = Hrs;
				StringType _NewApptRowPtr = NewApptRowPtr;
				StringType _NewApptRowNum = NewApptRowNum;
				InfobarType _Infobar = Infobar;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSSchedTeamLoadConflictSp";
					
					appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SchedDate", _SchedDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Hrs", _Hrs, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "NewApptRowPtr", _NewApptRowPtr, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "NewApptRowNum", _NewApptRowNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
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
