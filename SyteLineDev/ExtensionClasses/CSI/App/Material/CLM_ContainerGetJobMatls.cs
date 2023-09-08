//PROJECT NAME: Material
//CLASS NAME: CLM_ContainerGetJobMatls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CLM_ContainerGetJobMatls : ICLM_ContainerGetJobMatls
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ContainerGetJobMatls(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) CLM_ContainerGetJobMatlsSp(
			string Site = null,
			string JobJob = null,
			int? JobSuffix = null,
			string JobmatlOperNum = null,
			int? ExtScrap = 1,
			string CurWhse = null,
			int? ShowBFlushMatls = 0,
			string ContainerNum = null,
			string Infobar = null)
		{
			SiteType _Site = Site;
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			StringType _JobmatlOperNum = JobmatlOperNum;
			ListYesNoType _ExtScrap = ExtScrap;
			WhseType _CurWhse = CurWhse;
			ListYesNoType _ShowBFlushMatls = ShowBFlushMatls;
			ContainerNumType _ContainerNum = ContainerNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ContainerGetJobMatlsSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlOperNum", _JobmatlOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtScrap", _ExtScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowBFlushMatls", _ShowBFlushMatls, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
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
