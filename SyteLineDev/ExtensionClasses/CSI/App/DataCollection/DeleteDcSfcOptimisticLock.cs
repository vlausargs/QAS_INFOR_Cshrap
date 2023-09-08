//PROJECT NAME: DataCollection
//CLASS NAME: DeleteDcSfcOptimisticLock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DeleteDcSfcOptimisticLock : IDeleteDcSfcOptimisticLock
	{
		readonly IApplicationDB appDB;
		
		
		public DeleteDcSfcOptimisticLock(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteDcSfcOptimisticLockSp(int? TransNum,
		string OldStat,
		string OldErrorMsg,
		string OldRecordDate,
		string Infobar)
		{
			DcTransNumType _TransNum = TransNum;
			DcStatusType _OldStat = OldStat;
			InfobarType _OldErrorMsg = OldErrorMsg;
			LongListType _OldRecordDate = OldRecordDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteDcSfcOptimisticLockSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStat", _OldStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldErrorMsg", _OldErrorMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldRecordDate", _OldRecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
