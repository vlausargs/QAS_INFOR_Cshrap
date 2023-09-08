//PROJECT NAME: Reporting
//CLASS NAME: SSSPOSRpt_POSInc_R.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ISSSPOSRpt_POSInc_R
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSPOSRpt_POSInc_RSp(string tPrintInvNum,
		string tPrintPosmNum,
		byte? tTransDomCurr,
		string ParmCurrCode,
		string pSite = null);
	}
	
	public class SSSPOSRpt_POSInc_R : ISSSPOSRpt_POSInc_R
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSPOSRpt_POSInc_R(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSPOSRpt_POSInc_RSp(string tPrintInvNum,
		string tPrintPosmNum,
		byte? tTransDomCurr,
		string ParmCurrCode,
		string pSite = null)
		{
			InvNumType _tPrintInvNum = tPrintInvNum;
			POSMNumType _tPrintPosmNum = tPrintPosmNum;
			ListYesNoType _tTransDomCurr = tTransDomCurr;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSRpt_POSInc_RSp";
				
				appDB.AddCommandParameter(cmd, "tPrintInvNum", _tPrintInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tPrintPosmNum", _tPrintPosmNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tTransDomCurr", _tTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
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
