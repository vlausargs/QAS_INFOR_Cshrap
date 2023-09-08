//PROJECT NAME: Data
//CLASS NAME: ProcessJobTranPiece.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProcessJobTranPiece : IProcessJobTranPiece
	{
		readonly IApplicationDB appDB;
		
		public ProcessJobTranPiece(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProcessJobTranPieceSp(
			decimal? PTransNum,
			string Infobar)
		{
			HugeTransNumType _PTransNum = PTransNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessJobTranPieceSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
