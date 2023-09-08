//PROJECT NAME: Production
//CLASS NAME: XrefWarningMessage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class XrefWarningMessage : IXrefWarningMessage
	{
		readonly IApplicationDB appDB;
		
		
		public XrefWarningMessage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string WarningMsg) XrefWarningMessageSp(string NewRefType,
		string NewRefNum,
		int? NewRefLineSuf,
		int? NewRefRel,
		string WarningMsg)
		{
			UnknownRefTypeType _NewRefType = NewRefType;
			AnyRefNumType _NewRefNum = NewRefNum;
			CoLineType _NewRefLineSuf = NewRefLineSuf;
			CoLineType _NewRefRel = NewRefRel;
			Infobar _WarningMsg = WarningMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "XrefWarningMessageSp";
				
				appDB.AddCommandParameter(cmd, "NewRefType", _NewRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRefNum", _NewRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRefLineSuf", _NewRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRefRel", _NewRefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarningMsg", _WarningMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WarningMsg = _WarningMsg;
				
				return (Severity, WarningMsg);
			}
		}
	}
}
