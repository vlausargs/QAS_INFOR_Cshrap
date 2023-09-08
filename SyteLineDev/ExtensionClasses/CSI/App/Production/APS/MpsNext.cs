//PROJECT NAME: Production
//CLASS NAME: MpsNext.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class MpsNext : IMpsNext
	{
		readonly IApplicationDB appDB;
		
		
		public MpsNext(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PLastTran) MpsNextSp(string PLastTran)
		{
			UnknownRefNumLastTranType _PLastTran = PLastTran;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MpsNextSp";
				
				appDB.AddCommandParameter(cmd, "PLastTran", _PLastTran, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PLastTran = _PLastTran;
				
				return (Severity, PLastTran);
			}
		}
	}
}
