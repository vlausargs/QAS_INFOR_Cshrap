//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARBalanceReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ARBalanceReport : IRpt_ARBalanceReport
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ARBalanceReport(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_ARBalanceReportSp(string FromCustNum,
		string ToCustNum,
		int? FromPeriod,
		int? ToPeriod,
		int? FromYear,
		int? ToYear,
		int? DisplayHeader = null,
		string Infobar = null,
		string pSite = null)
		{
			CustNumType _FromCustNum = FromCustNum;
			CustNumType _ToCustNum = ToCustNum;
			FinPeriodType _FromPeriod = FromPeriod;
			FinPeriodType _ToPeriod = ToPeriod;
			FiscalYearType _FromYear = FromYear;
			FiscalYearType _ToYear = ToYear;
			FlagNyType _DisplayHeader = DisplayHeader;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ARBalanceReportSp";
				
				appDB.AddCommandParameter(cmd, "FromCustNum", _FromCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCustNum", _ToCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPeriod", _FromPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPeriod", _ToPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromYear", _FromYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToYear", _ToYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
