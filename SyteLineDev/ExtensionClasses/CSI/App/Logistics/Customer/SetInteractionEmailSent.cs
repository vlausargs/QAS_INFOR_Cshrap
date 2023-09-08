//PROJECT NAME: Logistics
//CLASS NAME: SetInteractionEmailSent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SetInteractionEmailSent : ISetInteractionEmailSent
	{
		readonly IApplicationDB appDB;
		
		
		public SetInteractionEmailSent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SetInteractionEmailSentSp(int? PEmailSent,
		string PInteractionType,
		Guid? PInteractionRP,
		string PUserName,
		string Infobar)
		{
			ListYesNoType _PEmailSent = PEmailSent;
			StringType _PInteractionType = PInteractionType;
			RowPointerType _PInteractionRP = PInteractionRP;
			UsernameType _PUserName = PUserName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetInteractionEmailSentSp";
				
				appDB.AddCommandParameter(cmd, "PEmailSent", _PEmailSent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInteractionType", _PInteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInteractionRP", _PInteractionRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserName", _PUserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
