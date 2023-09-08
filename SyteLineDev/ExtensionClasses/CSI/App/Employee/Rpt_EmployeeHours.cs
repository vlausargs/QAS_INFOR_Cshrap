//PROJECT NAME: Employee
//CLASS NAME: Rpt_EmployeeHours.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class Rpt_EmployeeHours : IRpt_EmployeeHours
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EmployeeHours(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeeHoursSp(string PEmpStarting,
		string PEmpEnding,
		DateTime? PDateStarting,
		DateTime? PDateEnding,
		decimal? PTransStarting,
		decimal? PTransEnding,
		string PEmpType,
		string PPayType,
		int? PPrintCost,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string PSite = null)
		{
			EmpNumType _PEmpStarting = PEmpStarting;
			EmpNumType _PEmpEnding = PEmpEnding;
			DateType _PDateStarting = PDateStarting;
			DateType _PDateEnding = PDateEnding;
			MatlTransNumType _PTransStarting = PTransStarting;
			MatlTransNumType _PTransEnding = PTransEnding;
			StringType _PEmpType = PEmpType;
			StringType _PPayType = PPayType;
			IntType _PPrintCost = PPrintCost;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EmployeeHoursSp";
				
				appDB.AddCommandParameter(cmd, "PEmpStarting", _PEmpStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpEnding", _PEmpEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDateStarting", _PDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDateEnding", _PDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransStarting", _PTransStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransEnding", _PTransEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpType", _PEmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintCost", _PPrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
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
