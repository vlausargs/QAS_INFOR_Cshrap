//PROJECT NAME: Reporting
//CLASS NAME: Rpt_YearToDateDeductionsandEarnings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_YearToDateDeductionsandEarnings : IRpt_YearToDateDeductionsandEarnings
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_YearToDateDeductionsandEarnings(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_YearToDateDeductionsandEarningsSp(string ExBegDepart = null,
		string ExEndDepart = null,
		string ExBegEmp = null,
		string ExEndEmp = null,
		DateTime? ExBegCheckDate = null,
		DateTime? ExEndCheckDate = null,
		string ExOptdfEmplType = null,
		string ExBegPrdecdCode = null,
		string ExEndPrdecdCode = null,
		string ExOptdfDeCodeType = null,
		string ExOptprPrSortBy = null,
		int? DisplayHeader = null,
		int? DateStartingOffset = null,
		int? DateEndingOffset = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null)
		{
			DeptType _ExBegDepart = ExBegDepart;
			DeptType _ExEndDepart = ExEndDepart;
			EmpNumType _ExBegEmp = ExBegEmp;
			EmpNumType _ExEndEmp = ExEndEmp;
			DateType _ExBegCheckDate = ExBegCheckDate;
			DateType _ExEndCheckDate = ExEndCheckDate;
			InfobarType _ExOptdfEmplType = ExOptdfEmplType;
			DeCodeType _ExBegPrdecdCode = ExBegPrdecdCode;
			DeCodeType _ExEndPrdecdCode = ExEndPrdecdCode;
			InfobarType _ExOptdfDeCodeType = ExOptdfDeCodeType;
			StringType _ExOptprPrSortBy = ExOptprPrSortBy;
			ListYesNoType _DisplayHeader = DisplayHeader;
			DateOffsetType _DateStartingOffset = DateStartingOffset;
			DateOffsetType _DateEndingOffset = DateEndingOffset;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_YearToDateDeductionsandEarningsSp";
				
				appDB.AddCommandParameter(cmd, "ExBegDepart", _ExBegDepart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndDepart", _ExEndDepart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegEmp", _ExBegEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndEmp", _ExEndEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegCheckDate", _ExBegCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndCheckDate", _ExEndCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEmplType", _ExOptdfEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegPrdecdCode", _ExBegPrdecdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndPrdecdCode", _ExEndPrdecdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfDeCodeType", _ExOptdfDeCodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPrSortBy", _ExOptprPrSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffset", _DateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffset", _DateEndingOffset, ParameterDirection.Input);
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
