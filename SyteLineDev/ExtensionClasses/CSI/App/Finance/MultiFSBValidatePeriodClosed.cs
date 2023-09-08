//PROJECT NAME: Finance
//CLASS NAME: MultiFSBValidatePeriodClosed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBValidatePeriodClosed
	{
		(int? ReturnCode, string Infobar) MultiFSBValidatePeriodClosedSp(int? FiscalYearClosed,
		                                                                 int? Closed,
		                                                                 string Infobar);
	}
	
	public class MultiFSBValidatePeriodClosed : IMultiFSBValidatePeriodClosed
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBValidatePeriodClosed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MultiFSBValidatePeriodClosedSp(int? FiscalYearClosed,
		                                                                        int? Closed,
		                                                                        string Infobar)
		{
			IntType _FiscalYearClosed = FiscalYearClosed;
			IntType _Closed = Closed;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBValidatePeriodClosedSp";
				
				appDB.AddCommandParameter(cmd, "FiscalYearClosed", _FiscalYearClosed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Closed", _Closed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
