//PROJECT NAME: Production
//CLASS NAME: RSQC_SerialCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SerialCheck : IRSQC_SerialCheck
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SerialCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_ErrorCode,
		string o_Messages,
		string Infobar) RSQC_SerialCheckSp(string SerNum,
		int? RcvNum,
		int? o_ErrorCode,
		string o_Messages,
		string Infobar)
		{
			SerNumType _SerNum = SerNum;
			IntType _RcvNum = RcvNum;
			ListYesNoType _o_ErrorCode = o_ErrorCode;
			InfobarType _o_Messages = o_Messages;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SerialCheckSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvNum", _RcvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_ErrorCode", _o_ErrorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_Messages", _o_Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_ErrorCode = _o_ErrorCode;
				o_Messages = _o_Messages;
				Infobar = _Infobar;
				
				return (Severity, o_ErrorCode, o_Messages, Infobar);
			}
		}
	}
}
