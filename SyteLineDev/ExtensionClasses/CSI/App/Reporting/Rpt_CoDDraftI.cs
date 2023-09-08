//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CoDDraftI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_CoDDraftI : IRpt_CoDDraftI
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CoDDraftI(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CoDDraftISp(
			string InvCred = null,
			string pInvHdrInvNum = null,
			string pInvHdrCoNum = null,
			string pVoidOrDraft = null,
			string BGSessionId = null,
			string pSite = null)
		{
			StringType _InvCred = InvCred;
			InvNumType _pInvHdrInvNum = pInvHdrInvNum;
			CoNumType _pInvHdrCoNum = pInvHdrCoNum;
			StringType _pVoidOrDraft = pVoidOrDraft;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CoDDraftISp";
				
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvHdrInvNum", _pInvHdrInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvHdrCoNum", _pInvHdrCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVoidOrDraft", _pVoidOrDraft, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
