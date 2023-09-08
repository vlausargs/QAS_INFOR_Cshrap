//PROJECT NAME: Data
//CLASS NAME: UpdPbal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdPbal : IUpdPbal
	{
		readonly IApplicationDB appDB;
		
		public UpdPbal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Message) UpdPbalSp(
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
				cmd.CommandText = "UpdPbalSp";
				
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
