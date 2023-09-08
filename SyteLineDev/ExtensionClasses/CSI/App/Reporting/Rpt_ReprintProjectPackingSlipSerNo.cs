//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintProjectPackingSlipSerNo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ReprintProjectPackingSlipSerNo : IRpt_ReprintProjectPackingSlipSerNo
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ReprintProjectPackingSlipSerNo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintProjectPackingSlipSerNoSp(
			string proj_num,
			int? task_num,
			int? seq)
		{
			ProjNumType _proj_num = proj_num;
			TaskNumType _task_num = task_num;
			ProjmatlSeqType _seq = seq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ReprintProjectPackingSlipSerNoSp";
				
				appDB.AddCommandParameter(cmd, "proj_num", _proj_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "task_num", _task_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "seq", _seq, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
