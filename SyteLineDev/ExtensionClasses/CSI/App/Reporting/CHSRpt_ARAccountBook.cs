//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_ARAccountBook.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_ARAccountBook
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_ARAccountBookSp(string BegCustNum,
		string EndCustNum,
		DateTime? BegDate,
		DateTime? EndDate,
		string CurrencyCode,
		byte? ViewDetailStats,
		string pSite = null);
	}
	
	public class CHSRpt_ARAccountBook : ICHSRpt_ARAccountBook
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_ARAccountBook(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_ARAccountBookSp(string BegCustNum,
		string EndCustNum,
		DateTime? BegDate,
		DateTime? EndDate,
		string CurrencyCode,
		byte? ViewDetailStats,
		string pSite = null)
		{
			CustNumType _BegCustNum = BegCustNum;
			CustNumType _EndCustNum = EndCustNum;
			DateType _BegDate = BegDate;
			DateType _EndDate = EndDate;
			CurrCodeType _CurrencyCode = CurrencyCode;
			ListYesNoType _ViewDetailStats = ViewDetailStats;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_ARAccountBookSp";
				
				appDB.AddCommandParameter(cmd, "BegCustNum", _BegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDate", _BegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyCode", _CurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ViewDetailStats", _ViewDetailStats, ParameterDirection.Input);
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
