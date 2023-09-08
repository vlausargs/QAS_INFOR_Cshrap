//PROJECT NAME: Production
//CLASS NAME: JobP2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobP2 : IJobP2
	{
		readonly IApplicationDB appDB;
		
		
		public JobP2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TCoby,
		string Infobar,
		string PromptButtons) JobP2Sp(Guid? SJobtranRowPointer,
		int? PPostNeg = 0,
		int? TCoby = null,
		string Infobar = null,
		string CurWhse = null,
		string PromptButtons = null,
		string DocumentNum = null)
		{
			RowPointerType _SJobtranRowPointer = SJobtranRowPointer;
			Flag _PPostNeg = PPostNeg;
			FlagNyType _TCoby = TCoby;
			InfobarType _Infobar = Infobar;
			WhseType _CurWhse = CurWhse;
			InfobarType _PromptButtons = PromptButtons;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobP2Sp";
				
				appDB.AddCommandParameter(cmd, "SJobtranRowPointer", _SJobtranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostNeg", _PPostNeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TCoby = _TCoby;
				Infobar = _Infobar;
				PromptButtons = _PromptButtons;
				
				return (Severity, TCoby, Infobar, PromptButtons);
			}
		}
	}
}
