//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_ManualVoucherPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_ManualVoucherPrint
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_ManualVoucherPrintSp(short? FiscalYear,
		byte? Period,
		string CrntNmbrStart,
		string CrntNmbrEnd,
		string TypeCode,
		DateTime? TransDate,
		string pSite = null);
	}
	
	public class CHSRpt_ManualVoucherPrint : ICHSRpt_ManualVoucherPrint
	{
		IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_ManualVoucherPrint(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_ManualVoucherPrintSp(short? FiscalYear,
		byte? Period,
		string CrntNmbrStart,
		string CrntNmbrEnd,
		string TypeCode,
		DateTime? TransDate,
		string pSite = null)
		{
			FiscalYearType _FiscalYear = FiscalYear;
			FinPeriodType _Period = Period;
			GenericMedCodeType _CrntNmbrStart = CrntNmbrStart;
			GenericMedCodeType _CrntNmbrEnd = CrntNmbrEnd;
			TransNatType _TypeCode = TypeCode;
			DateType _TransDate = TransDate;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_ManualVoucherPrintSp";
				
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrntNmbrStart", _CrntNmbrStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrntNmbrEnd", _CrntNmbrEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
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
