//PROJECT NAME: DataCollection
//CLASS NAME: DcwcLogError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcwcLogError : IDcwcLogError
	{
		readonly IApplicationDB appDB;
		
		
		public DcwcLogError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcwcLogErrorSp(int? PTransNum,
		string ErrorMsg)
		{
			DcTransNumType _PTransNum = PTransNum;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcwcLogErrorSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
