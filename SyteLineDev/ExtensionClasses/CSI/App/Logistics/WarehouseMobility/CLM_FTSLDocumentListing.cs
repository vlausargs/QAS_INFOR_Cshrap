//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLDocumentListing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLDocumentListing : ICLM_FTSLDocumentListing
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTSLDocumentListing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLDocumentListingSp(string Job = null,
		int? Suffix = null,
		int? ViewJob = 0,
		int? ReadSyteLine = 0,
		int? Operation = null,
		string Item = null,
		int? ViewOperation = 0,
		int? ViewItem = 0,
		int? ReadDocTrak = 0)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ListYesNoType _ViewJob = ViewJob;
			ListYesNoType _ReadSyteLine = ReadSyteLine;
			OperNumType _Operation = Operation;
			ItemType _Item = Item;
			ListYesNoType _ViewOperation = ViewOperation;
			ListYesNoType _ViewItem = ViewItem;
			ListYesNoType _ReadDocTrak = ReadDocTrak;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLDocumentListingSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ViewJob", _ViewJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReadSyteLine", _ReadSyteLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ViewOperation", _ViewOperation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ViewItem", _ViewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReadDocTrak", _ReadDocTrak, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
