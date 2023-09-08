//PROJECT NAME: DataCollection
//CLASS NAME: DcitemLogError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcitemLogError : IDcitemLogError
	{
		readonly IApplicationDB appDB;
		
		
		public DcitemLogError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcitemLogErrorSp(int? PTransNum,
		int? PCanOverride,
		string ErrorMsg)
		{
			DcTransNumType _PTransNum = PTransNum;
			ListYesNoType _PCanOverride = PCanOverride;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcitemLogErrorSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCanOverride", _PCanOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
