//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcLogError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcsfcLogError : IDcsfcLogError
	{
		readonly IApplicationDB appDB;
		
		
		public DcsfcLogError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcsfcLogErrorSp(int? PTransNum,
		int? PCanOverride,
		string ErrorMsg)
		{
			DcTransNumType _PTransNum = PTransNum;
			ListYesNoType _PCanOverride = PCanOverride;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcsfcLogErrorSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCanOverride", _PCanOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
