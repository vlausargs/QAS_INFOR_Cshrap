//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadSyncExpense.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadSyncExpense
	{
		int LoadSyncExpenseSp(string EmpNum,
		                      string StatusCode,
		                      decimal? Amount,
		                      string DocumentID,
		                      ref string Infobar);
	}
	
	public class LoadSyncExpense : ILoadSyncExpense
	{
		readonly IApplicationDB appDB;
		
		public LoadSyncExpense(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadSyncExpenseSp(string EmpNum,
		                             string StatusCode,
		                             decimal? Amount,
		                             string DocumentID,
		                             ref string Infobar)
		{
			EmpNumType _EmpNum = EmpNum;
			StringType _StatusCode = StatusCode;
			PrAmountType _Amount = Amount;
			LongDescType _DocumentID = DocumentID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadSyncExpenseSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusCode", _StatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
