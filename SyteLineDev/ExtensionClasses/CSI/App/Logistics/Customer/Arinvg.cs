//PROJECT NAME: Logistics
//CLASS NAME: Arinvg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Arinvg : IArinvg
	{
		readonly IApplicationDB appDB;
		
		
		public Arinvg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ArinvgSp(Guid? PArinv,
		string Infobar,
		Guid? EarnedRebateRowPointer = null)
		{
			RowPointerType _PArinv = PArinv;
			Infobar _Infobar = Infobar;
			RowPointerType _EarnedRebateRowPointer = EarnedRebateRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArinvgSp";
				
				appDB.AddCommandParameter(cmd, "PArinv", _PArinv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EarnedRebateRowPointer", _EarnedRebateRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
