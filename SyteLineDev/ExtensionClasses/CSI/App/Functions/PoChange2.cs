//PROJECT NAME: Data
//CLASS NAME: PoChange2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoChange2 : IPoChange2
	{
		readonly IApplicationDB appDB;
		
		public PoChange2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PoChange,
			int? PoChangePrompt2User) PoChange2Sp(
			string PoNum,
			string PoStatus,
			int? PoChange,
			int? PoChangePrompt2User)
		{
			PoNumType _PoNum = PoNum;
			PoStatusType _PoStatus = PoStatus;
			ListYesNoType _PoChange = PoChange;
			ListYesNoType _PoChangePrompt2User = PoChangePrompt2User;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoChange2Sp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoStatus", _PoStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChange", _PoChange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChangePrompt2User", _PoChangePrompt2User, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoChange = _PoChange;
				PoChangePrompt2User = _PoChangePrompt2User;
				
				return (Severity, PoChange, PoChangePrompt2User);
			}
		}
	}
}
