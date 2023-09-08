//PROJECT NAME: Data
//CLASS NAME: PoChange1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoChange1 : IPoChange1
	{
		readonly IApplicationDB appDB;
		
		public PoChange1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PoChangePrompt1User,
			string Infobar) PoChange1Sp(
			string PoNum,
			string PoStatus,
			int? PoChangePrompt1User,
			string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoStatusType _PoStatus = PoStatus;
			ListYesNoType _PoChangePrompt1User = PoChangePrompt1User;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoChange1Sp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoStatus", _PoStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChangePrompt1User", _PoChangePrompt1User, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoChangePrompt1User = _PoChangePrompt1User;
				Infobar = _Infobar;
				
				return (Severity, PoChangePrompt1User, Infobar);
			}
		}
	}
}
