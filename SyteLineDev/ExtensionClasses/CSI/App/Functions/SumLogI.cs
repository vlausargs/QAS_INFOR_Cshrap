//PROJECT NAME: Data
//CLASS NAME: SumLogI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SumLogI : ISumLogI
	{
		readonly IApplicationDB appDB;
		
		public SumLogI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SumLogISp(
			string PEmpNum,
			int? PSeq,
			DateTime? PCurStart,
			DateTime? PCurEnd)
		{
			EmpNumType _PEmpNum = PEmpNum;
			PrtrxSeqType _PSeq = PSeq;
			DateType _PCurStart = PCurStart;
			DateType _PCurEnd = PCurEnd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumLogISp";
				
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurStart", _PCurStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurEnd", _PCurEnd, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
