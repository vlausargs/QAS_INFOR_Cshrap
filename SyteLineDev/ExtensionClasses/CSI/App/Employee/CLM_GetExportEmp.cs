//PROJECT NAME: CSIEmployee
//CLASS NAME: CLM_GetExportEmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface ICLM_GetExportEmp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetExportEmpSp(string StartingDept,
		string EndingDept,
		string StartingEmpNum,
		string EndingEmpNum,
		byte? IsExportChangedOnly = (byte)0,
		string FilterString = null);
	}
	
	public class CLM_GetExportEmp : ICLM_GetExportEmp
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetExportEmp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetExportEmpSp(string StartingDept,
		string EndingDept,
		string StartingEmpNum,
		string EndingEmpNum,
		byte? IsExportChangedOnly = (byte)0,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				DeptType _StartingDept = StartingDept;
				DeptType _EndingDept = EndingDept;
				EmpNumType _StartingEmpNum = StartingEmpNum;
				EmpNumType _EndingEmpNum = EndingEmpNum;
				ListYesNoType _IsExportChangedOnly = IsExportChangedOnly;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_GetExportEmpSp";
					
					appDB.AddCommandParameter(cmd, "StartingDept", _StartingDept, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingDept", _EndingDept, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingEmpNum", _StartingEmpNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingEmpNum", _EndingEmpNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IsExportChangedOnly", _IsExportChangedOnly, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
