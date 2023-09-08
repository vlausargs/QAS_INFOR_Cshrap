//PROJECT NAME: Data
//CLASS NAME: GenConstraintMsg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GenConstraintMsg : IGenConstraintMsg
	{
		readonly IApplicationDB appDB;
		
		public GenConstraintMsg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GenConstraintMsgSp(
			string TableFilter = null,
			string MessageLanguage = null,
			int? DeleteExistingMsg = 0,
			string Infobar = null)
		{
			StringType _TableFilter = TableFilter;
			StringType _MessageLanguage = MessageLanguage;
			ListYesNoType _DeleteExistingMsg = DeleteExistingMsg;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenConstraintMsgSp";
				
				appDB.AddCommandParameter(cmd, "TableFilter", _TableFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteExistingMsg", _DeleteExistingMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
