//PROJECT NAME: Data
//CLASS NAME: RemoteLoadTmpSer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RemoteLoadTmpSer : IRemoteLoadTmpSer
	{
		readonly IApplicationDB appDB;
		
		public RemoteLoadTmpSer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RemoteLoadTmpSerSp(
			Guid? TmpSerId,
			string SerNum,
			string RefStr,
			string TrxRestrictCode)
		{
			RowPointerType _TmpSerId = TmpSerId;
			SerNumType _SerNum = SerNum;
			RefStrType _RefStr = RefStr;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteLoadTmpSerSp";
				
				appDB.AddCommandParameter(cmd, "TmpSerId", _TmpSerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStr", _RefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
