//PROJECT NAME: Reporting
//CLASS NAME: WBCanInvValSubItemloc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.CriticalNumber
{
	public class WBCanInvValSubItemloc : IWBCanInvValSubItemloc
	{
		readonly IApplicationDB appDB;
		
		public WBCanInvValSubItemloc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Amount) WBCanInvValSubItemlocSp(
			Guid? ItemlocRowPointer,
			decimal? Amount)
		{
			RowPointerType _ItemlocRowPointer = ItemlocRowPointer;
			AmountType _Amount = Amount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBCanInvValSubItemlocSp";
				
				appDB.AddCommandParameter(cmd, "ItemlocRowPointer", _ItemlocRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Amount = _Amount;
				
				return (Severity, Amount);
			}
		}
	}
}
