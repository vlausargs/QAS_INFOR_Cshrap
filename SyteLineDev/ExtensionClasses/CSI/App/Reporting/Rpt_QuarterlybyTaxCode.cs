//PROJECT NAME: Reporting
//CLASS NAME: Rpt_QuarterlybyTaxCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_QuarterlybyTaxCode : IRpt_QuarterlybyTaxCode
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_QuarterlybyTaxCode(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_QuarterlybyTaxCodeSp(DateTime? CheckDateStarting = null,
		DateTime? CheckDateEnding = null,
		string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		int? CheckDateStartingOffset = null,
		int? CheckDateEndingOffset = null,
		int? DisplayHeader = null,
		int? EmpTypeHourlyPerm = null,
		int? EmpTypeSalaryPerm = null,
		string pSite = null)
		{
			DateType _CheckDateStarting = CheckDateStarting;
			DateType _CheckDateEnding = CheckDateEnding;
			PrTaxCodeType _TaxCodeStarting = TaxCodeStarting;
			PrTaxCodeType _TaxCodeEnding = TaxCodeEnding;
			DateOffsetType _CheckDateStartingOffset = CheckDateStartingOffset;
			DateOffsetType _CheckDateEndingOffset = CheckDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			PrivilegeType _EmpTypeHourlyPerm = EmpTypeHourlyPerm;
			PrivilegeType _EmpTypeSalaryPerm = EmpTypeSalaryPerm;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_QuarterlybyTaxCodeSp";
				
				appDB.AddCommandParameter(cmd, "CheckDateStarting", _CheckDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateEnding", _CheckDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeStarting", _TaxCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeEnding", _TaxCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateStartingOffset", _CheckDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDateEndingOffset", _CheckDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpTypeHourlyPerm", _EmpTypeHourlyPerm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpTypeSalaryPerm", _EmpTypeSalaryPerm, ParameterDirection.Input);
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
