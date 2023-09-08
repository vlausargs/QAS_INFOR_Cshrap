//PROJECT NAME: Finance
//CLASS NAME: FaCostsNextSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FaCostsNextSeq : IFaCostsNextSeq
	{
		readonly IApplicationDB appDB;
		
		
		public FaCostsNextSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pSeq,
		string Infobar) FaCostsNextSeqSp(string pFaNum,
		int? pSeq,
		string Infobar)
		{
			FaNumType _pFaNum = pFaNum;
			FaCostSeqType _pSeq = pSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FaCostsNextSeqSp";
				
				appDB.AddCommandParameter(cmd, "pFaNum", _pFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSeq", _pSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pSeq = _pSeq;
				Infobar = _Infobar;
				
				return (Severity, pSeq, Infobar);
			}
		}
	}
}
