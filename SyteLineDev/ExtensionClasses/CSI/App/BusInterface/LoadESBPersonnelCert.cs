//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBPersonnelCert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBPersonnelCert : ILoadESBPersonnelCert
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBPersonnelCert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadESBPersonnelCertSp(string ActionExpression = null,
		string EmpNum = null,
		string Licert = null,
		DateTime? EffDate = null,
		string State = null,
		string Infobar = null)
		{
			StringType _ActionExpression = ActionExpression;
			EmpNumType _EmpNum = EmpNum;
			LicertType _Licert = Licert;
			DateType _EffDate = EffDate;
			StateType _State = State;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBPersonnelCertSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Licert", _Licert, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
