//PROJECT NAME: Data
//CLASS NAME: ValidPoBeforeSyncCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidPoBeforeSyncCo : IValidPoBeforeSyncCo
	{
		readonly IApplicationDB appDB;
		
		public ValidPoBeforeSyncCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ValidPoBeforeSyncCoSp(
			string DemandingPO,
			int? UpdateHeader = 0,
			int? BlanketLine = 0,
			int? PoItemsPoLine = null,
			int? PoItemsPoRelease = null,
			string PoItems = null,
			int? PreassignLots = null,
			int? PreassignSerials = null,
			int? AutoReceiveDemandingSitePO = null,
			string Infobar = null)
		{
			PoNumType _DemandingPO = DemandingPO;
			ListYesNoType _UpdateHeader = UpdateHeader;
			ListYesNoType _BlanketLine = BlanketLine;
			PoLineType _PoItemsPoLine = PoItemsPoLine;
			PoReleaseType _PoItemsPoRelease = PoItemsPoRelease;
			ItemType _PoItems = PoItems;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			ListYesNoType _AutoReceiveDemandingSitePO = AutoReceiveDemandingSitePO;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidPoBeforeSyncCoSp";
				
				appDB.AddCommandParameter(cmd, "DemandingPO", _DemandingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateHeader", _UpdateHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketLine", _BlanketLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsPoLine", _PoItemsPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemsPoRelease", _PoItemsPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItems", _PoItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoReceiveDemandingSitePO", _AutoReceiveDemandingSitePO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
