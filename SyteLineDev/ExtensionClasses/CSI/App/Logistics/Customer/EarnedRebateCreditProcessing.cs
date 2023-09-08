//PROJECT NAME: Logistics
//CLASS NAME: EarnedRebateCreditProcessing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EarnedRebateCreditProcessing : IEarnedRebateCreditProcessing
	{
		readonly IApplicationDB appDB;
		
		
		public EarnedRebateCreditProcessing(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) EarnedRebateCreditProcessingSp(Guid? EarnedRebateRowPointer,
		DateTime? ApplicationDate,
		string Infobar)
		{
			RowPointerType _EarnedRebateRowPointer = EarnedRebateRowPointer;
			DateType _ApplicationDate = ApplicationDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EarnedRebateCreditProcessingSp";
				
				appDB.AddCommandParameter(cmd, "EarnedRebateRowPointer", _EarnedRebateRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApplicationDate", _ApplicationDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
