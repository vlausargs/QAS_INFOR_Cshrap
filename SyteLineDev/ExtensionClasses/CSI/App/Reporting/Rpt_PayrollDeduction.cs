//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PayrollDeduction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PayrollDeduction : IRpt_PayrollDeduction
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PayrollDeduction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PayrollDeductionSp(DateTime? CheckDate = null,
		string EmpStarting = null,
		string EmpEnding = null,
		int? PrintAllTrx = null,
		string EmpType = null,
		int? CheckDateOffset = null,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null)
		{
			DateType _CheckDate = CheckDate;
			EmpNumType _EmpStarting = EmpStarting;
			EmpNumType _EmpEnding = EmpEnding;
			FlagNyType _PrintAllTrx = PrintAllTrx;
			InfobarType _EmpType = EmpType;
			DateOffsetType _CheckDateOffset = CheckDateOffset;
			FlagNyType _DisplayHeader = DisplayHeader;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PayrollDeductionSp";
				
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpStarting", _EmpStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpEnding", _EmpEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintAllTrx", _PrintAllTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpType", _EmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateOffset", _CheckDateOffset, ParameterDirection.Input);
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
