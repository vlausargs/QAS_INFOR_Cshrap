//PROJECT NAME: Data
//CLASS NAME: RemoteOrderCreditHold.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RemoteOrderCreditHold : IRemoteOrderCreditHold
	{
		readonly IApplicationDB appDB;
		
		public RemoteOrderCreditHold(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Counter) RemoteOrderCreditHoldSp(
			string StartingOrder,
			string EndingOrder,
			string cust_num,
			string Reason,
			string Infobar,
			int? Counter = 0,
			decimal? UserId = null)
		{
			CoNumType _StartingOrder = StartingOrder;
			CoNumType _EndingOrder = EndingOrder;
			CustNumType _cust_num = cust_num;
			ReasonCodeType _Reason = Reason;
			InfobarType _Infobar = Infobar;
			IntType _Counter = Counter;
			TokenType _UserId = UserId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteOrderCreditHoldSp";
				
				appDB.AddCommandParameter(cmd, "StartingOrder", _StartingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrder", _EndingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cust_num", _cust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reason", _Reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Counter", _Counter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Counter = _Counter;
				
				return (Severity, Counter);
			}
		}
	}
}
