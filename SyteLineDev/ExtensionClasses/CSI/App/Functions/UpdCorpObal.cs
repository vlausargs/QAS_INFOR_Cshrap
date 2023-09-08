//PROJECT NAME: Data
//CLASS NAME: UpdCorpObal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdCorpObal : IUpdCorpObal
	{
		readonly IApplicationDB appDB;
		
		public UpdCorpObal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Message) UpdCorpObalSp(
			string CorpCustNum,
			decimal? Adjust,
			string Operator,
			string Message)
		{
			CustNumType _CorpCustNum = CorpCustNum;
			AmountType _Adjust = Adjust;
			StringType _Operator = Operator;
			InfobarType _Message = Message;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdCorpObalSp";
				
				appDB.AddCommandParameter(cmd, "CorpCustNum", _CorpCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Adjust", _Adjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operator", _Operator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Message", _Message, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Message = _Message;
				
				return (Severity, Message);
			}
		}
	}
}
