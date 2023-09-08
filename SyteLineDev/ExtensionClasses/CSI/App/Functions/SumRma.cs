//PROJECT NAME: Data
//CLASS NAME: SumRma.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SumRma : ISumRma
	{
		readonly IApplicationDB appDB;
		
		public SumRma(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? RmaTotCredit,
			string Infobar) SumRmaSp(
			string PRmaNum,
			decimal? RmaTotCredit,
			string Infobar)
		{
			RmaNumType _PRmaNum = PRmaNum;
			AmountType _RmaTotCredit = RmaTotCredit;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumRmaSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaTotCredit", _RmaTotCredit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RmaTotCredit = _RmaTotCredit;
				Infobar = _Infobar;
				
				return (Severity, RmaTotCredit, Infobar);
			}
		}
	}
}
