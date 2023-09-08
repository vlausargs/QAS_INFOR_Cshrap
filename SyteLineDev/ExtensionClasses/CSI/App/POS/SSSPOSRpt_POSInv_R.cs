//PROJECT NAME: POS
//CLASS NAME: SSSPOSRpt_POSInv_R.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSRpt_POSInv_R : ISSSPOSRpt_POSInv_R
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSPOSRpt_POSInv_R(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSPOSRpt_POSInv_RSp(
			string tPrintInvNum,
			string tPrintPosmNum,
			int? tTransDomCurr,
			string ParmCurrCode)
		{
			InvNumType _tPrintInvNum = tPrintInvNum;
			POSMNumType _tPrintPosmNum = tPrintPosmNum;
			ListYesNoType _tTransDomCurr = tTransDomCurr;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSRpt_POSInv_RSp";
				
				appDB.AddCommandParameter(cmd, "tPrintInvNum", _tPrintInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tPrintPosmNum", _tPrintPosmNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tTransDomCurr", _tTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
