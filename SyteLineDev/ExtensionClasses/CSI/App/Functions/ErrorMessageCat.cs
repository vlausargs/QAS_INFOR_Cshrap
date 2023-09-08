//PROJECT NAME: Data
//CLASS NAME: ErrorMessageCat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ErrorMessageCat : IErrorMessageCat
	{
		readonly IApplicationDB appDB;
		
		public ErrorMessageCat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string MsgCat) ErrorMessageCatSp(
			string Msg1 = null,
			string Msg2 = null,
			string Msg3 = null,
			string Msg4 = null,
			string Msg5 = null,
			string Msg6 = null,
			string Msg7 = null,
			string Msg8 = null,
			string Msg9 = null,
			string Msg10 = null,
			string MsgCat = null)
		{
			ObjectNameType _Msg1 = Msg1;
			ObjectNameType _Msg2 = Msg2;
			ObjectNameType _Msg3 = Msg3;
			ObjectNameType _Msg4 = Msg4;
			ObjectNameType _Msg5 = Msg5;
			ObjectNameType _Msg6 = Msg6;
			ObjectNameType _Msg7 = Msg7;
			ObjectNameType _Msg8 = Msg8;
			ObjectNameType _Msg9 = Msg9;
			ObjectNameType _Msg10 = Msg10;
			InfobarType _MsgCat = MsgCat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ErrorMessageCatSp";
				
				appDB.AddCommandParameter(cmd, "Msg1", _Msg1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg2", _Msg2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg3", _Msg3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg4", _Msg4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg5", _Msg5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg6", _Msg6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg7", _Msg7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg8", _Msg8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg9", _Msg9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Msg10", _Msg10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsgCat", _MsgCat, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MsgCat = _MsgCat;
				
				return (Severity, MsgCat);
			}
		}
	}
}
