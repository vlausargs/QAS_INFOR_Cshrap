//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_APAccountBook.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class CHSRpt_APAccountBook : ICHSRpt_APAccountBook
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_APAccountBook(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_APAccountBookSp(string BegVendNum,
		string EndVendNum,
		DateTime? BegDate,
		DateTime? EndDate,
		string CurrencyCode,
		int? ViewDetailStats,
		string pSite = null)
		{
			VendNumType _BegVendNum = BegVendNum;
			VendNumType _EndVendNum = EndVendNum;
			DateType _BegDate = BegDate;
			DateType _EndDate = EndDate;
			CurrCodeType _CurrencyCode = CurrencyCode;
			ListYesNoType _ViewDetailStats = ViewDetailStats;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_APAccountBookSp";
				
				appDB.AddCommandParameter(cmd, "BegVendNum", _BegVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
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
