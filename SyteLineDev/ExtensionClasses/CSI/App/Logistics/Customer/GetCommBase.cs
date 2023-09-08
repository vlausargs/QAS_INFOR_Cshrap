//PROJECT NAME: CSICustomer
//CLASS NAME: GetCommBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetCommBase
	{
		int GetCommBaseSp(string CoNum,
		                  short? CoLine,
		                  ref decimal? CommBase);

		decimal? GetCommBaseFn(
			string CoNum,
			int? CoLine);
	}
	
	public class GetCommBase : IGetCommBase
	{
		readonly IApplicationDB appDB;
		
		public GetCommBase(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetCommBaseSp(string CoNum,
		                         short? CoLine,
		                         ref decimal? CommBase)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CostPrcType _CommBase = CommBase;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCommBaseSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommBase", _CommBase, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CommBase = _CommBase;
				
				return Severity;
			}
		}

		public decimal? GetCommBaseFn(
			string CoNum,
			int? CoLine)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetCommBase](@CoNum, @CoLine)";

				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}
	}
}
