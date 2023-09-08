//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBExpenseReportLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBExpenseReportLine
	{
		int LoadESBExpenseReportLineSp(string DerBODID,
		                               string EmployeeID,
		                               string ApproveStatus,
		                               string LineNumber,
		                               ref string Infobar);
	}
	
	public class LoadESBExpenseReportLine : ILoadESBExpenseReportLine
	{
		readonly IApplicationDB appDB;
		
		public LoadESBExpenseReportLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBExpenseReportLineSp(string DerBODID,
		                                      string EmployeeID,
		                                      string ApproveStatus,
		                                      string LineNumber,
		                                      ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _EmployeeID = EmployeeID;
			StringType _ApproveStatus = ApproveStatus;
			StringType _LineNumber = LineNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBExpenseReportLineSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeID", _EmployeeID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApproveStatus", _ApproveStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineNumber", _LineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
