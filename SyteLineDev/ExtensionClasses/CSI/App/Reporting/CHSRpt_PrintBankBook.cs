//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_PrintBankBook.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_PrintBankBook
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_PrintBankBookSp(string PBankCode,
		DateTime? PDateFrom,
		DateTime? PDateTo,
		string pSite = null);
	}
	
	public class CHSRpt_PrintBankBook : ICHSRpt_PrintBankBook
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_PrintBankBook(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_PrintBankBookSp(string PBankCode,
		DateTime? PDateFrom,
		DateTime? PDateTo,
		string pSite = null)
		{
			BankCodeType _PBankCode = PBankCode;
			DateType _PDateFrom = PDateFrom;
			DateType _PDateTo = PDateTo;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_PrintBankBookSp";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDateFrom", _PDateFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDateTo", _PDateTo, ParameterDirection.Input);
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
