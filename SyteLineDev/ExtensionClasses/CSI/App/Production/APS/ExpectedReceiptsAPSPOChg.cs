//PROJECT NAME: CSIAPS
//CLASS NAME: ExpectedReceiptsAPSPOChg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IExpectedReceiptsAPSPOChg
	{
		int ExpectedReceiptsAPSPOChgSp(string PONum,
		                               short? POLine,
		                               short? PORelease,
		                               ref DateTime? DueDate,
		                               ref decimal? QtyOrdered);
	}
	
	public class ExpectedReceiptsAPSPOChg : IExpectedReceiptsAPSPOChg
	{
		readonly IApplicationDB appDB;
		
		public ExpectedReceiptsAPSPOChg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ExpectedReceiptsAPSPOChgSp(string PONum,
		                                      short? POLine,
		                                      short? PORelease,
		                                      ref DateTime? DueDate,
		                                      ref decimal? QtyOrdered)
		{
			PoNumType _PONum = PONum;
			PoLineType _POLine = POLine;
			PoReleaseType _PORelease = PORelease;
			DateType _DueDate = DueDate;
			QtyUnitNoNegType _QtyOrdered = QtyOrdered;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExpectedReceiptsAPSPOChgSp";
				
				appDB.AddCommandParameter(cmd, "PONum", _PONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POLine", _POLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PORelease", _PORelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				QtyOrdered = _QtyOrdered;
				
				return Severity;
			}
		}
	}
}
