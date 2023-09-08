//PROJECT NAME: Data
//CLASS NAME: PoinvP2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoinvP2 : IPoinvP2
	{
		readonly IApplicationDB appDB;
		
		public PoinvP2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PoinvP2Sp(
			string PPoNum,
			int? PSeqNum)
		{
			PoNumType _PPoNum = PPoNum;
			EdiSeqType _PSeqNum = PSeqNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoinvP2Sp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeqNum", _PSeqNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
