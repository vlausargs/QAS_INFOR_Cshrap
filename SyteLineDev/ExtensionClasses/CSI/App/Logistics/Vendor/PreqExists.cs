//PROJECT NAME: CSIVendor
//CLASS NAME: PreqExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPreqExists
	{
		int PreqExistsSp(string ReqNum,
		                 ref byte? PreqExists);
	}
	
	public class PreqExists : IPreqExists
	{
		readonly IApplicationDB appDB;
		
		public PreqExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PreqExistsSp(string ReqNum,
		                        ref byte? PreqExists)
		{
			ReqNumType _ReqNum = ReqNum;
			FlagNyType _PreqExists = PreqExists;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreqExistsSp";
				
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqExists", _PreqExists, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PreqExists = _PreqExists;
				
				return Severity;
			}
		}
	}
}
