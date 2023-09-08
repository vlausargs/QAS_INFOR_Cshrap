//PROJECT NAME: Production
//CLASS NAME: ApsTraceMsg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsTraceMsg : IApsTraceMsg
	{
		readonly IApplicationDB appDB;
		
		public ApsTraceMsg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsTraceMsgSp(
			string Msg,
			int? AltNo = 0)
		{
			StringType _Msg = Msg;
			ShortType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsTraceMsgSp";
				
				appDB.AddCommandParameter(cmd, "Msg", _Msg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
