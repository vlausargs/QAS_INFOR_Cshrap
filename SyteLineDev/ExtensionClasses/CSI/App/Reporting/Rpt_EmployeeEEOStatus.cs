//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EmployeeEEOStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EmployeeEEOStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeeEEOStatusSp(string SEeoClass = null,
		string EEeoClass = null,
		string SEmpNum = null,
		string EEmpNum = null,
		string SDept = null,
		string EDept = null,
		DateTime? SHireDate = null,
		DateTime? EHireDate = null,
		string EmpStatus = null,
		string SortBy = null,
		short? SHireDateOffset = null,
		short? EHireDateOffset = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_EmployeeEEOStatus : IRpt_EmployeeEEOStatus
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EmployeeEEOStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeeEEOStatusSp(string SEeoClass = null,
		string EEeoClass = null,
		string SEmpNum = null,
		string EEmpNum = null,
		string SDept = null,
		string EDept = null,
		DateTime? SHireDate = null,
		DateTime? EHireDate = null,
		string EmpStatus = null,
		string SortBy = null,
		short? SHireDateOffset = null,
		short? EHireDateOffset = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			EEOClsType _SEeoClass = SEeoClass;
			EEOClsType _EEeoClass = EEeoClass;
			EmpNumType _SEmpNum = SEmpNum;
			EmpNumType _EEmpNum = EEmpNum;
			DeptType _SDept = SDept;
			DeptType _EDept = EDept;
			DateType _SHireDate = SHireDate;
			DateType _EHireDate = EHireDate;
			StringType _EmpStatus = EmpStatus;
			StringType _SortBy = SortBy;
			DateOffsetType _SHireDateOffset = SHireDateOffset;
			DateOffsetType _EHireDateOffset = EHireDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EmployeeEEOStatusSp";
				
				appDB.AddCommandParameter(cmd, "SEeoClass", _SEeoClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EEeoClass", _EEeoClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SEmpNum", _SEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EEmpNum", _EEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDept", _SDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EDept", _EDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHireDate", _SHireDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EHireDate", _EHireDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpStatus", _EmpStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHireDateOffset", _SHireDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EHireDateOffset", _EHireDateOffset, ParameterDirection.Input);
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
