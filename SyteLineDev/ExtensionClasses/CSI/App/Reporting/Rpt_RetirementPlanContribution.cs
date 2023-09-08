//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RetirementPlanContribution.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RetirementPlanContribution : IRpt_RetirementPlanContribution
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RetirementPlanContribution(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RetirementPlanContributionSp(string DeparmentStarting = null,
		string DeparmentEnding = null,
		string EmployeeStarting = null,
		string EmployeeEnding = null,
		DateTime? CheckDateStarting = null,
		DateTime? CheckDateEnding = null,
		string DECodeStarting = null,
		string DECodeEnding = null,
		string DECodeType = null,
		string EmployeeTypes = null,
		int? CheckDateStartingOffset = null,
		int? CheckDateEndingOffset = null,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null)
		{
			DeptType _DeparmentStarting = DeparmentStarting;
			DeptType _DeparmentEnding = DeparmentEnding;
			EmpNumType _EmployeeStarting = EmployeeStarting;
			EmpNumType _EmployeeEnding = EmployeeEnding;
			DateType _CheckDateStarting = CheckDateStarting;
			DateType _CheckDateEnding = CheckDateEnding;
			DeCodeType _DECodeStarting = DECodeStarting;
			DeCodeType _DECodeEnding = DECodeEnding;
			InfobarType _DECodeType = DECodeType;
			InfobarType _EmployeeTypes = EmployeeTypes;
			DateOffsetType _CheckDateStartingOffset = CheckDateStartingOffset;
			DateOffsetType _CheckDateEndingOffset = CheckDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RetirementPlanContributionSp";
				
				appDB.AddCommandParameter(cmd, "DeparmentStarting", _DeparmentStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeparmentEnding", _DeparmentEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeStarting", _EmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeEnding", _EmployeeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateStarting", _CheckDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateEnding", _CheckDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DECodeStarting", _DECodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DECodeEnding", _DECodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DECodeType", _DECodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeTypes", _EmployeeTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateStartingOffset", _CheckDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateEndingOffset", _CheckDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
