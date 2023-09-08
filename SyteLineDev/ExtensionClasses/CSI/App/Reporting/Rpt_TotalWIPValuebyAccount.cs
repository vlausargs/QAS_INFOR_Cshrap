//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TotalWIPValuebyAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TotalWIPValuebyAccount : IRpt_TotalWIPValuebyAccount
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TotalWIPValuebyAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TotalWIPValuebyAccountSp(string SAcct = null,
		string EAcct = null,
		string ExBegproductcode = null,
		string ExEndProductcode = null,
		string ExBegItem = null,
		string ExEndItem = null,
		string ExBegjob = null,
		string ExEndJob = null,
		int? ExBegSuffix = null,
		int? ExEndSuffix = null,
		string ExOptgoJJobStat = null,
		int? PUnitCode1 = 0,
		int? PUnitCode2 = 0,
		int? PUnitCode3 = 0,
		int? PUnitCode4 = 0,
		int? Displayheader = null,
		string SRONumBeg = null,
		string SRONumEnd = null,
		string SROOperStatus = null,
		string pSite = null)
		{
			AcctType _SAcct = SAcct;
			AcctType _EAcct = EAcct;
			ProductCodeType _ExBegproductcode = ExBegproductcode;
			ProductCodeType _ExEndProductcode = ExEndProductcode;
			ItemType _ExBegItem = ExBegItem;
			ItemType _ExEndItem = ExEndItem;
			JobType _ExBegjob = ExBegjob;
			JobType _ExEndJob = ExEndJob;
			SuffixType _ExBegSuffix = ExBegSuffix;
			SuffixType _ExEndSuffix = ExEndSuffix;
			Infobar _ExOptgoJJobStat = ExOptgoJJobStat;
			ListYesNoType _PUnitCode1 = PUnitCode1;
			ListYesNoType _PUnitCode2 = PUnitCode2;
			ListYesNoType _PUnitCode3 = PUnitCode3;
			ListYesNoType _PUnitCode4 = PUnitCode4;
			ListYesNoType _Displayheader = Displayheader;
			CoNumType _SRONumBeg = SRONumBeg;
			CoNumType _SRONumEnd = SRONumEnd;
			Infobar _SROOperStatus = SROOperStatus;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TotalWIPValuebyAccountSp";
				
				appDB.AddCommandParameter(cmd, "SAcct", _SAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcct", _EAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegproductcode", _ExBegproductcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndProductcode", _ExEndProductcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegItem", _ExBegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndItem", _ExEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegjob", _ExBegjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndJob", _ExEndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegSuffix", _ExBegSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndSuffix", _ExEndSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoJJobStat", _ExOptgoJJobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode1", _PUnitCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode2", _PUnitCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode3", _PUnitCode3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode4", _PUnitCode4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Displayheader", _Displayheader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONumBeg", _SRONumBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONumEnd", _SRONumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOperStatus", _SROOperStatus, ParameterDirection.Input);
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
