//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_PostProjectLaborTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface ICLM_PostProjectLaborTrans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PostProjectLaborTransSp(string ProjectStarting = null,
		string ProjectEnding = null,
		DateTime? TransactionDateStarting = null,
		DateTime? TransactionDateEnding = null,
		string EmployeeStarting = null,
		string EmployeeEnding = null,
		short? DateStartingOffSET = null,
		short? DateEndingOffSET = null,
		Guid? PSessionId = null);
	}
	
	public class CLM_PostProjectLaborTrans : ICLM_PostProjectLaborTrans
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PostProjectLaborTrans(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PostProjectLaborTransSp(string ProjectStarting = null,
		string ProjectEnding = null,
		DateTime? TransactionDateStarting = null,
		DateTime? TransactionDateEnding = null,
		string EmployeeStarting = null,
		string EmployeeEnding = null,
		short? DateStartingOffSET = null,
		short? DateEndingOffSET = null,
		Guid? PSessionId = null)
		{
			ProjNumType _ProjectStarting = ProjectStarting;
			ProjNumType _ProjectEnding = ProjectEnding;
			DateType _TransactionDateStarting = TransactionDateStarting;
			DateType _TransactionDateEnding = TransactionDateEnding;
			EmpNumType _EmployeeStarting = EmployeeStarting;
			EmpNumType _EmployeeEnding = EmployeeEnding;
			DateOffsetType _DateStartingOffSET = DateStartingOffSET;
			DateOffsetType _DateEndingOffSET = DateEndingOffSET;
			RowPointerType _PSessionId = PSessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_PostProjectLaborTransSp";
				
				appDB.AddCommandParameter(cmd, "ProjectStarting", _ProjectStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectEnding", _ProjectEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionDateStarting", _TransactionDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionDateEnding", _TransactionDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeStarting", _EmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeEnding", _EmployeeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffSET", _DateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffSET", _DateEndingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
