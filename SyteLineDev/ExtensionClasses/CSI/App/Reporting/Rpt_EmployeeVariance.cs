//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EmployeeVariance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EmployeeVariance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeeVarianceSp(string ExBegEmpnum = null,
		string ExEndEmpnum = null,
		string ExOptprPostedEmp = null,
		string ExOptdfEmplType = null,
		DateTime? ExBegTrANDate = null,
		DateTime? ExEndTrANDate = null,
		string ExBegJob = null,
		string ExEndJob = null,
		short? ExBegsuffix = null,
		short? ExEndsuffix = null,
		short? TrANDateStartingOffSET = null,
		short? TrANDateENDingOffSET = null,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_EmployeeVariance : IRpt_EmployeeVariance
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EmployeeVariance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeeVarianceSp(string ExBegEmpnum = null,
		string ExEndEmpnum = null,
		string ExOptprPostedEmp = null,
		string ExOptdfEmplType = null,
		DateTime? ExBegTrANDate = null,
		DateTime? ExEndTrANDate = null,
		string ExBegJob = null,
		string ExEndJob = null,
		short? ExBegsuffix = null,
		short? ExEndsuffix = null,
		short? TrANDateStartingOffSET = null,
		short? TrANDateENDingOffSET = null,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			EmpNumType _ExBegEmpnum = ExBegEmpnum;
			EmpNumType _ExEndEmpnum = ExEndEmpnum;
			StringType _ExOptprPostedEmp = ExOptprPostedEmp;
			InfobarType _ExOptdfEmplType = ExOptdfEmplType;
			DateType _ExBegTrANDate = ExBegTrANDate;
			DateType _ExEndTrANDate = ExEndTrANDate;
			JobType _ExBegJob = ExBegJob;
			JobType _ExEndJob = ExEndJob;
			SuffixType _ExBegsuffix = ExBegsuffix;
			SuffixType _ExEndsuffix = ExEndsuffix;
			DateOffsetType _TrANDateStartingOffSET = TrANDateStartingOffSET;
			DateOffsetType _TrANDateENDingOffSET = TrANDateENDingOffSET;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EmployeeVarianceSp";
				
				appDB.AddCommandParameter(cmd, "ExBegEmpnum", _ExBegEmpnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndEmpnum", _ExEndEmpnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostedEmp", _ExOptprPostedEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEmplType", _ExOptdfEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegTrANDate", _ExBegTrANDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndTrANDate", _ExEndTrANDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegJob", _ExBegJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndJob", _ExEndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegsuffix", _ExBegsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndsuffix", _ExEndsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrANDateStartingOffSET", _TrANDateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrANDateENDingOffSET", _TrANDateENDingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
