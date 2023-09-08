//PROJECT NAME: DataCollection
//CLASS NAME: DcpsLogError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcpsLogError : IDcpsLogError
	{
		readonly IApplicationDB appDB;
		
		
		public DcpsLogError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcpsLogErrorSp(int? PTransNum,
		string ErrorMsg)
		{
			DcTransNumType _PTransNum = PTransNum;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcpsLogErrorSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
