//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EmployeeLogHours.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_EmployeeLogHours : IRpt_EmployeeLogHours
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EmployeeLogHours(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeeLogHoursSp(string PStartingEmployee = null,
		string PEndingEmployee = null,
		DateTime? PStartingDate = null,
		DateTime? PEndingDate = null,
		decimal? PStartingTrans = null,
		decimal? PEndingTrans = null,
		string PCheckType = null,
		string PPayType = null,
		string PEmployeeType = null,
		int? PStartingDateOffset = null,
		int? PEndingDateOffset = null,
		int? PrintCost = 0,
		int? PDisplayHeader = 1,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null)
		{
			EmpNumType _PStartingEmployee = PStartingEmployee;
			EmpNumType _PEndingEmployee = PEndingEmployee;
			DateType _PStartingDate = PStartingDate;
			DateType _PEndingDate = PEndingDate;
			MatlTransNumType _PStartingTrans = PStartingTrans;
			MatlTransNumType _PEndingTrans = PEndingTrans;
			Infobar _PCheckType = PCheckType;
			Infobar _PPayType = PPayType;
			Infobar _PEmployeeType = PEmployeeType;
			DateOffsetType _PStartingDateOffset = PStartingDateOffset;
			DateOffsetType _PEndingDateOffset = PEndingDateOffset;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EmployeeLogHoursSp";
				
				appDB.AddCommandParameter(cmd, "PStartingEmployee", _PStartingEmployee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingEmployee", _PEndingEmployee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingDate", _PStartingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingDate", _PEndingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingTrans", _PStartingTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingTrans", _PEndingTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckType", _PCheckType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmployeeType", _PEmployeeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingDateOffset", _PStartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingDateOffset", _PEndingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
