//PROJECT NAME: Admin
//CLASS NAME: SumJourCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface ISumJourCheck
	{
		(int? ReturnCode, string Buttons, string Infobar) SumJourCheckSp(string Id,
		DateTime? PSDate = null,
		DateTime? PEDate = null,
		string Buttons = null,
		string Infobar = null);
	}
	
	public class SumJourCheck : ISumJourCheck
	{
		IApplicationDB appDB;
		
		public SumJourCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Buttons, string Infobar) SumJourCheckSp(string Id,
		DateTime? PSDate = null,
		DateTime? PEDate = null,
		string Buttons = null,
		string Infobar = null)
		{
			JournalIdType _Id = Id;
			CurrentDateType _PSDate = PSDate;
			CurrentDateType _PEDate = PEDate;
			InfobarType _Buttons = Buttons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumJourCheckSp";
				
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSDate", _PSDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEDate", _PEDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Buttons = _Buttons;
				Infobar = _Infobar;
				
				return (Severity, Buttons, Infobar);
			}
		}
	}
}
