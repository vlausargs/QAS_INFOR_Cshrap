//PROJECT NAME: Production
//CLASS NAME: Rpt_PendingMaterialTransactions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Rpt_PendingMaterialTransactions : IRpt_PendingMaterialTransactions
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PendingMaterialTransactions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PendingMaterialTransactionsSp(decimal? PTransNumStarting,
		decimal? PTransNumEnding,
		DateTime? PTransDateStarting,
		DateTime? PTransDateEnding,
		string PJobStarting,
		string PJobEnding,
		int? PSuffixStarting,
		int? PSuffixEnding,
		string PItemStarting,
		string PItemEnding,
		string PLocationStarting,
		string PLocationEnding,
		string PEmployeeStarting,
		string PEmployeeEnding,
		string PTransClass,
		string PSite = null)
		{
			HugeTransNumType _PTransNumStarting = PTransNumStarting;
			HugeTransNumType _PTransNumEnding = PTransNumEnding;
			DateType _PTransDateStarting = PTransDateStarting;
			DateType _PTransDateEnding = PTransDateEnding;
			JobType _PJobStarting = PJobStarting;
			JobType _PJobEnding = PJobEnding;
			SuffixType _PSuffixStarting = PSuffixStarting;
			SuffixType _PSuffixEnding = PSuffixEnding;
			ItemType _PItemStarting = PItemStarting;
			ItemType _PItemEnding = PItemEnding;
			LocType _PLocationStarting = PLocationStarting;
			LocType _PLocationEnding = PLocationEnding;
			EmpNumType _PEmployeeStarting = PEmployeeStarting;
			EmpNumType _PEmployeeEnding = PEmployeeEnding;
			StringType _PTransClass = PTransClass;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PendingMaterialTransactionsSp";
				
				appDB.AddCommandParameter(cmd, "PTransNumStarting", _PTransNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNumEnding", _PTransNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDateStarting", _PTransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDateEnding", _PTransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobStarting", _PJobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobEnding", _PJobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffixStarting", _PSuffixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffixEnding", _PSuffixEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemStarting", _PItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemEnding", _PItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLocationStarting", _PLocationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLocationEnding", _PLocationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmployeeStarting", _PEmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmployeeEnding", _PEmployeeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransClass", _PTransClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
