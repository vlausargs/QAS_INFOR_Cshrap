//PROJECT NAME: Employee
//CLASS NAME: Rpt_SalariesbyDepartment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class Rpt_SalariesbyDepartment : IRpt_SalariesbyDepartment
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SalariesbyDepartment(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalariesbyDepartmentSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PDepartmentStarting,
		string PDepartmentEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEEOClassStarting,
		string PEEOClassEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		string PSite = null)
		{
			EmpNumType _PEmployeeStarting = PEmployeeStarting;
			EmpNumType _PEmployeeEnding = PEmployeeEnding;
			DeptType _PDepartmentStarting = PDepartmentStarting;
			DeptType _PDepartmentEnding = PDepartmentEnding;
			DateType _PHireDateStarting = PHireDateStarting;
			DateType _PHireDateEnding = PHireDateEnding;
			EEOClsType _PEEOClassStarting = PEEOClassStarting;
			EEOClsType _PEEOClassEnding = PEEOClassEnding;
			StringType _PEmploymentStatus = PEmploymentStatus;
			StringType _PEmployeeTypes = PEmployeeTypes;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SalariesbyDepartmentSp";
				
				appDB.AddCommandParameter(cmd, "PEmployeeStarting", _PEmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmployeeEnding", _PEmployeeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDepartmentStarting", _PDepartmentStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDepartmentEnding", _PDepartmentEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHireDateStarting", _PHireDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHireDateEnding", _PHireDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEEOClassStarting", _PEEOClassStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEEOClassEnding", _PEEOClassEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmploymentStatus", _PEmploymentStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmployeeTypes", _PEmployeeTypes, ParameterDirection.Input);
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
