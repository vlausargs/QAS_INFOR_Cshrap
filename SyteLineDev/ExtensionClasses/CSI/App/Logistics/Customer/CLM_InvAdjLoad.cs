//PROJECT NAME: Logistics
//CLASS NAME: CLM_InvAdjLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_InvAdjLoad : ICLM_InvAdjLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_InvAdjLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_InvAdjLoadSp(string PrevCoNum,
		string PCoNum,
		string PApplyToInvNum,
		decimal? UserId,
		string Filter = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CoNumType _PrevCoNum = PrevCoNum;
				CoNumType _PCoNum = PCoNum;
				InvNumType _PApplyToInvNum = PApplyToInvNum;
				TokenType _UserId = UserId;
				LongListType _Filter = Filter;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_InvAdjLoadSp";
					
					appDB.AddCommandParameter(cmd, "PrevCoNum", _PrevCoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PApplyToInvNum", _PApplyToInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
