//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_GetBatchedJobMatls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface ICLM_GetBatchedJobMatls
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_GetBatchedJobMatlsSp(string Site,
		int? ProdBatchId,
		string JobmatlItem,
		string JobmatlDesc,
		byte? ExtScrap,
		string CurWhse,
		byte? ShowBFlushMatls,
		string ContainerNum,
		string Infobar);
	}
	
	public class CLM_GetBatchedJobMatls : ICLM_GetBatchedJobMatls
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetBatchedJobMatls(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_GetBatchedJobMatlsSp(string Site,
		int? ProdBatchId,
		string JobmatlItem,
		string JobmatlDesc,
		byte? ExtScrap,
		string CurWhse,
		byte? ShowBFlushMatls,
		string ContainerNum,
		string Infobar)
		{
			SiteType _Site = Site;
			ApsBatchNumberType _ProdBatchId = ProdBatchId;
			ItemType _JobmatlItem = JobmatlItem;
			DescriptionType _JobmatlDesc = JobmatlDesc;
			ListYesNoType _ExtScrap = ExtScrap;
			WhseType _CurWhse = CurWhse;
			ListYesNoType _ShowBFlushMatls = ShowBFlushMatls;
			ContainerNumType _ContainerNum = ContainerNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetBatchedJobMatlsSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdBatchId", _ProdBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlItem", _JobmatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlDesc", _JobmatlDesc, ParameterDirection.Input);
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
