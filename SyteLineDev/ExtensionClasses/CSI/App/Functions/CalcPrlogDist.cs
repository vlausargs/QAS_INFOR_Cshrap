//PROJECT NAME: Data
//CLASS NAME: CalcPrlogDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcPrlogDist : ICalcPrlogDist
	{
		readonly IApplicationDB appDB;
		
		public CalcPrlogDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CalcPrlogDistFn(
			string pEmpNum,
			int? pSeq)
		{
			EmpNumType _pEmpNum = pEmpNum;
			PrtrxSeqType _pSeq = pSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcPrlogDist](@pEmpNum, @pSeq)";
				
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSeq", _pSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
