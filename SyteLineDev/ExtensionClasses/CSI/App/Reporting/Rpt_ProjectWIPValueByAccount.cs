//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectWIPValueByAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectWIPValueByAccount : IRpt_ProjectWIPValueByAccount
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectWIPValueByAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectWIPValueByAccountSp(string StartingAccount = null,
		string EndingAccount = null,
		string StartingProdCode = null,
		string EndingProdCode = null,
		string ProjectStatus = null,
		int? PUnitCode1 = 0,
		int? PUnitCode2 = 0,
		int? PUnitCode3 = 0,
		int? PUnitCode4 = 0,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			AcctType _StartingAccount = StartingAccount;
			AcctType _EndingAccount = EndingAccount;
			ProductCodeType _StartingProdCode = StartingProdCode;
			ProductCodeType _EndingProdCode = EndingProdCode;
			InfobarType _ProjectStatus = ProjectStatus;
			ListYesNoType _PUnitCode1 = PUnitCode1;
			ListYesNoType _PUnitCode2 = PUnitCode2;
			ListYesNoType _PUnitCode3 = PUnitCode3;
			ListYesNoType _PUnitCode4 = PUnitCode4;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectWIPValueByAccountSp";
				
				appDB.AddCommandParameter(cmd, "StartingAccount", _StartingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAccount", _EndingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingProdCode", _StartingProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProdCode", _EndingProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectStatus", _ProjectStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode1", _PUnitCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode2", _PUnitCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode3", _PUnitCode3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode4", _PUnitCode4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
