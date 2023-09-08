//PROJECT NAME: Production
//CLASS NAME: WhatIfExpectedReceiptsPOChg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class WhatIfExpectedReceiptsPOChg : IWhatIfExpectedReceiptsPOChg
	{
		readonly IApplicationDB appDB;
		
		
		public WhatIfExpectedReceiptsPOChg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? DueDate,
		string QtyOrdered) WhatIfExpectedReceiptsPOChgSp(int? AltNo,
		string PONum = null,
		DateTime? DueDate = null,
		string QtyOrdered = null)
		{
			ApsAltNoType _AltNo = AltNo;
			ApsOrderType _PONum = PONum;
			DateTimeType _DueDate = DueDate;
			ApsExprType _QtyOrdered = QtyOrdered;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WhatIfExpectedReceiptsPOChgSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PONum", _PONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				QtyOrdered = _QtyOrdered;
				
				return (Severity, DueDate, QtyOrdered);
			}
		}
	}
}
