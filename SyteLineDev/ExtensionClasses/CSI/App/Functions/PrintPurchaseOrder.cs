//PROJECT NAME: Data
//CLASS NAME: PrintPurchaseOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PrintPurchaseOrder : IPrintPurchaseOrder
	{
		readonly IApplicationDB appDB;
		
		public PrintPurchaseOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PrintPurchaseOrderSp(
			string StartPoNum = null,
			string EndPoNum = null,
			int? StartPoLine = null,
			int? EndPoLine = null,
			string UserName = null,
			string LangCode = null)
		{
			PoNumType _StartPoNum = StartPoNum;
			PoNumType _EndPoNum = EndPoNum;
			PoLineType _StartPoLine = StartPoLine;
			PoLineType _EndPoLine = EndPoLine;
			UsernameType _UserName = UserName;
			LangCodeType _LangCode = LangCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintPurchaseOrderSp";
				
				appDB.AddCommandParameter(cmd, "StartPoNum", _StartPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPoNum", _EndPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPoLine", _StartPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPoLine", _EndPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
