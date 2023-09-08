//PROJECT NAME: Admin
//CLASS NAME: UpdateUserStartFormSubForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class UpdateUserStartFormSubForm : IUpdateUserStartFormSubForm
	{
		IApplicationDB appDB;
		
		
		public UpdateUserStartFormSubForm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateUserStartFormSubFormSp(string Username,
		string SubFormName,
		int? SubFormInstanceId,
		int? Selected,
		decimal? Sequence,
		string Infobar)
		{
			UsernameType _Username = Username;
			FormNameType _SubFormName = SubFormName;
			WBKPINumType _SubFormInstanceId = SubFormInstanceId;
			ListYesNoType _Selected = Selected;
			SequenceType _Sequence = Sequence;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateUserStartFormSubFormSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubFormName", _SubFormName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubFormInstanceId", _SubFormInstanceId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
