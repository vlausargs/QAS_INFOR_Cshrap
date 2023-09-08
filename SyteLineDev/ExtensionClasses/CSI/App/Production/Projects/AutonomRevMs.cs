//PROJECT NAME: Production
//CLASS NAME: AutonomRevMs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class AutonomRevMs : IAutonomRevMs
	{
		readonly IApplicationDB appDB;
		
		
		public AutonomRevMs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CanBeNom,
		DateTime? NomDate,
		int? TReq,
		int? PNotProcess,
		string Infobar) AutonomRevMsSp(string InProjNum,
		string InMsNum,
		int? CanBeNom,
		DateTime? NomDate,
		int? TReq,
		int? PNotProcess,
		string Infobar)
		{
			ProjNumType _InProjNum = InProjNum;
			ProjMsNumType _InMsNum = InMsNum;
			FlagNyType _CanBeNom = CanBeNom;
			CurrentDateType _NomDate = NomDate;
			FlagNyType _TReq = TReq;
			GenericNoType _PNotProcess = PNotProcess;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AutonomRevMsSp";
				
				appDB.AddCommandParameter(cmd, "InProjNum", _InProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InMsNum", _InMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanBeNom", _CanBeNom, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NomDate", _NomDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TReq", _TReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNotProcess", _PNotProcess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanBeNom = _CanBeNom;
				NomDate = _NomDate;
				TReq = _TReq;
				PNotProcess = _PNotProcess;
				Infobar = _Infobar;
				
				return (Severity, CanBeNom, NomDate, TReq, PNotProcess, Infobar);
			}
		}
	}
}
