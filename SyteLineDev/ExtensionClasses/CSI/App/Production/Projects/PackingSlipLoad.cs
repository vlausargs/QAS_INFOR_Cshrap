//PROJECT NAME: Production
//CLASS NAME: PackingSlipLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class PackingSlipLoad : IPackingSlipLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PackingSlipLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) PackingSlipLoadSp(string TPckCall,
		string ProjNum,
		string CustNum,
		int? FromTaskNum,
		int? ToTaskNum,
		int? FromSeq,
		int? ToSeq,
		string FilterString)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _TPckCall = TPckCall;
				ProjNumType _ProjNum = ProjNum;
				CustNumType _CustNum = CustNum;
				TaskNumType _FromTaskNum = FromTaskNum;
				TaskNumType _ToTaskNum = ToTaskNum;
				ProjmatlSeqType _FromSeq = FromSeq;
				ProjmatlSeqType _ToSeq = ToSeq;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "PackingSlipLoadSp";
					
					appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromTaskNum", _FromTaskNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToTaskNum", _ToTaskNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromSeq", _FromSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToSeq", _ToSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
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
