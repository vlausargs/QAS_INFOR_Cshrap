//PROJECT NAME: Data
//CLASS NAME: RemoteCoHld5.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RemoteCoHld5 : IRemoteCoHld5
	{
		readonly IApplicationDB appDB;
		
		public RemoteCoHld5(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RemoteCoHld5Sp(
			string PCustNum,
			string PCoNum)
		{
			CustNumType _PCustNum = PCustNum;
			CoNumType _PCoNum = PCoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteCoHld5Sp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
