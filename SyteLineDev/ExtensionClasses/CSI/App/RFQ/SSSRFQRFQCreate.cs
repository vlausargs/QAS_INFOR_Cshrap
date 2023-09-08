//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQRFQCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQRFQCreate : ISSSRFQRFQCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQRFQCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSRFQRFQCreateSp(
			string RollupMethod,
			string AppendRfqNum,
			string PSessionId,
			string Infobar)
		{
			StringType _RollupMethod = RollupMethod;
			RFQNumType _AppendRfqNum = AppendRfqNum;
			StringType _PSessionId = PSessionId;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQRFQCreateSp";
				
				appDB.AddCommandParameter(cmd, "RollupMethod", _RollupMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppendRfqNum", _AppendRfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
