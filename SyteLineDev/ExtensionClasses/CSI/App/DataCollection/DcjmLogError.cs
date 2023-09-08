//PROJECT NAME: DataCollection
//CLASS NAME: DcjmLogError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjmLogError : IDcjmLogError
	{
		readonly IApplicationDB appDB;
		
		
		public DcjmLogError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcjmLogErrorSp(int? PTransNum,
		int? pCanOverride,
		string ErrorMsg)
		{
			DcTransNumType _PTransNum = PTransNum;
			IntType _pCanOverride = pCanOverride;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcjmLogErrorSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCanOverride", _pCanOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
