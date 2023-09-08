//PROJECT NAME: Data
//CLASS NAME: EdiInOrderP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiInOrderP : IEdiInOrderP
	{
		readonly IApplicationDB appDB;
		
		public EdiInOrderP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PEdiCoCount,
			int? PPostedCount,
			string Infobar) EdiInOrderPSp(
			string PEdiCoNum,
			int? PEdiCoCount,
			int? PPostedCount,
			string Infobar,
			int? AutoPost = 0,
			decimal? ProcessId = null)
		{
			CoNumType _PEdiCoNum = PEdiCoNum;
			GenericNoType _PEdiCoCount = PEdiCoCount;
			GenericNoType _PPostedCount = PPostedCount;
			InfobarType _Infobar = Infobar;
			ListYesNoType _AutoPost = AutoPost;
			TokenType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiInOrderPSp";
				
				appDB.AddCommandParameter(cmd, "PEdiCoNum", _PEdiCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEdiCoCount", _PEdiCoCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPostedCount", _PPostedCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoPost", _AutoPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEdiCoCount = _PEdiCoCount;
				PPostedCount = _PPostedCount;
				Infobar = _Infobar;
				
				return (Severity, PEdiCoCount, PPostedCount, Infobar);
			}
		}
	}
}
