//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PostedPayrollTransactions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PostedPayrollTransactions : IRpt_PostedPayrollTransactions
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PostedPayrollTransactions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PostedPayrollTransactionsSp(string ExOptdfEmplType = null,
		string ExBegDepart = null,
		string ExEndDepart = null,
		DateTime? ExBegCheckDate = null,
		DateTime? ExEndCheckDate = null,
		int? DateStartingOffSET = null,
		int? DateEndingOffSET = null,
		string ExBegEmp = null,
		string ExEndEmp = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null,
		int? IsSubReport = 0)
		{
			InfobarType _ExOptdfEmplType = ExOptdfEmplType;
			DeptType _ExBegDepart = ExBegDepart;
			DeptType _ExEndDepart = ExEndDepart;
			DateType _ExBegCheckDate = ExBegCheckDate;
			DateType _ExEndCheckDate = ExEndCheckDate;
			DateOffsetType _DateStartingOffSET = DateStartingOffSET;
			DateOffsetType _DateEndingOffSET = DateEndingOffSET;
			EmpNumType _ExBegEmp = ExBegEmp;
			EmpNumType _ExEndEmp = ExEndEmp;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			ListYesNoType _IsSubReport = IsSubReport;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PostedPayrollTransactionsSp";
				
				appDB.AddCommandParameter(cmd, "ExOptdfEmplType", _ExOptdfEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegDepart", _ExBegDepart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndDepart", _ExEndDepart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegCheckDate", _ExBegCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndCheckDate", _ExEndCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffSET", _DateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffSET", _DateEndingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegEmp", _ExBegEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndEmp", _ExEndEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsSubReport", _IsSubReport, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
