//PROJECT NAME: Employee
//CLASS NAME: Rpt_SalariesByPositionClass.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class Rpt_SalariesByPositionClass : IRpt_SalariesByPositionClass
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SalariesByPositionClass(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalariesByPositionClassSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PEmpCategoryStarting,
		string PEmpCategoryEnding,
		string PClassificationStarting,
		string PClassificationEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		string PSite = null)
		{
			EmpNumType _PEmployeeStarting = PEmployeeStarting;
			EmpNumType _PEmployeeEnding = PEmployeeEnding;
			EmpCategoryType _PEmpCategoryStarting = PEmpCategoryStarting;
			EmpCategoryType _PEmpCategoryEnding = PEmpCategoryEnding;
			PosClassType _PClassificationStarting = PClassificationStarting;
			PosClassType _PClassificationEnding = PClassificationEnding;
			DateType _PHireDateStarting = PHireDateStarting;
			DateType _PHireDateEnding = PHireDateEnding;
			StringType _PEmploymentStatus = PEmploymentStatus;
			StringType _PEmployeeTypes = PEmployeeTypes;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SalariesByPositionClassSp";
				
				appDB.AddCommandParameter(cmd, "PEmployeeStarting", _PEmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmployeeEnding", _PEmployeeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpCategoryStarting", _PEmpCategoryStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpCategoryEnding", _PEmpCategoryEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PClassificationStarting", _PClassificationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PClassificationEnding", _PClassificationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHireDateStarting", _PHireDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHireDateEnding", _PHireDateEnding, ParameterDirection.Input);
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
