//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncEscalActive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSIncEscalActive : ISSSFSIncEscalActive
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncEscalActive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSIncEscalActiveSp(
			string IncNum,
			int? Seq,
			string Infobar)
		{
			FSIncNumType _IncNum = IncNum;
			FSSeqType _Seq = Seq;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncEscalActiveSp";
				
				appDB.AddCommandParameter(cmd, "IncNum", _IncNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
