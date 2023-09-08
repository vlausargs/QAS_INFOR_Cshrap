//PROJECT NAME: Logistics
//CLASS NAME: VerifyPackedNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class VerifyPackedNum : IVerifyPackedNum
	{
		readonly IApplicationDB appDB;
		
		
		public VerifyPackedNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Flag) VerifyPackedNumSp(string OrderNum,
		int? OrderLine,
		int? OrderRelease,
		decimal? OrderQty,
		int? Flag)
		{
			CoNumType _OrderNum = OrderNum;
			CoLineType _OrderLine = OrderLine;
			CoReleaseType _OrderRelease = OrderRelease;
			QtyPerType _OrderQty = OrderQty;
			IntType _Flag = Flag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyPackedNumSp";
				
				appDB.AddCommandParameter(cmd, "OrderNum", _OrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLine", _OrderLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderRelease", _OrderRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderQty", _OrderQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Flag", _Flag, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Flag = _Flag;
				
				return (Severity, Flag);
			}
		}
	}
}
