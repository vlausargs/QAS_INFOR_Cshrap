//PROJECT NAME: DataCollection
//CLASS NAME: DcpoLogError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcpoLogError : IDcpoLogError
	{
		readonly IApplicationDB appDB;
		
		
		public DcpoLogError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcpoLogErrorSp(int? PTransNum,
		string ErrorMsg)
		{
			DcTransNumType _PTransNum = PTransNum;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcpoLogErrorSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
