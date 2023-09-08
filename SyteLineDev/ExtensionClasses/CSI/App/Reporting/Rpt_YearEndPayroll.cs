//PROJECT NAME: Reporting
//CLASS NAME: Rpt_YearEndPayroll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_YearEndPayroll : IRpt_YearEndPayroll
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_YearEndPayroll(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_YearEndPayrollSp(string ExBegDepart = null,
		string ExEndDepart = null,
		string ExBegEmp = null,
		string ExEndEmp = null,
		string ExOptdfEmplType = null,
		int? ExOptprPageBetween = null,
		DateTime? ExBegQuarter1 = null,
		DateTime? ExEndQuarter1 = null,
		DateTime? ExOptprQuarter2 = null,
		DateTime? ExOptprQuarter3 = null,
		DateTime? ExOptprQuarter4 = null,
		int? DateStartingOffSET = null,
		int? DateEndingOffSET = null,
		int? DateQuarter2OffSET = null,
		int? DateQuarter3OffSET = null,
		int? DateQuarter4OffSET = null,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null)
		{
			DeptType _ExBegDepart = ExBegDepart;
			DeptType _ExEndDepart = ExEndDepart;
			EmpNumType _ExBegEmp = ExBegEmp;
			EmpNumType _ExEndEmp = ExEndEmp;
			InfobarType _ExOptdfEmplType = ExOptdfEmplType;
			ListYesNoType _ExOptprPageBetween = ExOptprPageBetween;
			DateType _ExBegQuarter1 = ExBegQuarter1;
			DateType _ExEndQuarter1 = ExEndQuarter1;
			DateType _ExOptprQuarter2 = ExOptprQuarter2;
			DateType _ExOptprQuarter3 = ExOptprQuarter3;
			DateType _ExOptprQuarter4 = ExOptprQuarter4;
			DateOffsetType _DateStartingOffSET = DateStartingOffSET;
			DateOffsetType _DateEndingOffSET = DateEndingOffSET;
			DateOffsetType _DateQuarter2OffSET = DateQuarter2OffSET;
			DateOffsetType _DateQuarter3OffSET = DateQuarter3OffSET;
			DateOffsetType _DateQuarter4OffSET = DateQuarter4OffSET;
			ListYesNoType _DisplayHeader = DisplayHeader;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_YearEndPayrollSp";
				
				appDB.AddCommandParameter(cmd, "ExBegDepart", _ExBegDepart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndDepart", _ExEndDepart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegEmp", _ExBegEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndEmp", _ExEndEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEmplType", _ExOptdfEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPageBetween", _ExOptprPageBetween, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegQuarter1", _ExBegQuarter1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndQuarter1", _ExEndQuarter1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprQuarter2", _ExOptprQuarter2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprQuarter3", _ExOptprQuarter3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprQuarter4", _ExOptprQuarter4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffSET", _DateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffSET", _DateEndingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateQuarter2OffSET", _DateQuarter2OffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateQuarter3OffSET", _DateQuarter3OffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateQuarter4OffSET", _DateQuarter4OffSET, ParameterDirection.Input);
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
