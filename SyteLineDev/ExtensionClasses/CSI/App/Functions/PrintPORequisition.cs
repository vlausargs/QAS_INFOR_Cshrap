//PROJECT NAME: Data
//CLASS NAME: PrintPORequisition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PrintPORequisition : IPrintPORequisition
	{
		readonly IApplicationDB appDB;
		
		public PrintPORequisition(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PrintPORequisitionSp(
			string StartReqNum = null,
			string EndReqNum = null,
			string UserName = null,
			string LangCode = null)
		{
			ReqNumType _StartReqNum = StartReqNum;
			ReqNumType _EndReqNum = EndReqNum;
			UsernameType _UserName = UserName;
			LangCodeType _LangCode = LangCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintPORequisitionSp";
				
				appDB.AddCommandParameter(cmd, "StartReqNum", _StartReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReqNum", _EndReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
