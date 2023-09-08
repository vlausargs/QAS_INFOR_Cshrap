//PROJECT NAME: Data
//CLASS NAME: CalFudgeAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalFudgeAmount : ICalFudgeAmount
	{
		readonly IApplicationDB appDB;
		
		public CalFudgeAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Fudge,
			int? NumLines) CalFudgeAmountSp(
			string InvNum,
			string CurrCode,
			decimal? Fudge,
			int? NumLines)
		{
			InvNumType _InvNum = InvNum;
			CurrCodeType _CurrCode = CurrCode;
			AmountType _Fudge = Fudge;
			IntType _NumLines = NumLines;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalFudgeAmountSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Fudge", _Fudge, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumLines", _NumLines, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Fudge = _Fudge;
				NumLines = _NumLines;
				
				return (Severity, Fudge, NumLines);
			}
		}
	}
}
