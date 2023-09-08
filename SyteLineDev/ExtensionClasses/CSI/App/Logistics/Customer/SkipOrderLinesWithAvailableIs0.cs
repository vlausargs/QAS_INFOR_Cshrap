//PROJECT NAME: Logistics
//CLASS NAME: SkipOrderLinesWithAvailableIs0.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SkipOrderLinesWithAvailableIs0 : ISkipOrderLinesWithAvailableIs0
	{
		readonly IApplicationDB appDB;
		
		
		public SkipOrderLinesWithAvailableIs0(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SkipOrderLinesWithAvailableIs0Sp(Guid? ProcessId,
		int? SkipOrderLineWhenQuantityAvailableIs0,
		int? IncludeZeroQuantityAvailableKitItems,
		string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _SkipOrderLineWhenQuantityAvailableIs0 = SkipOrderLineWhenQuantityAvailableIs0;
			ListYesNoType _IncludeZeroQuantityAvailableKitItems = IncludeZeroQuantityAvailableKitItems;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SkipOrderLinesWithAvailableIs0Sp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipOrderLineWhenQuantityAvailableIs0", _SkipOrderLineWhenQuantityAvailableIs0, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeZeroQuantityAvailableKitItems", _IncludeZeroQuantityAvailableKitItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
