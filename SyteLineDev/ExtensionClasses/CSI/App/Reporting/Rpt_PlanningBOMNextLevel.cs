//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PlanningBOMNextLevel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PlanningBOMNextLevel : IRpt_PlanningBOMNextLevel
	{
		readonly IApplicationDB appDB;
		
		public Rpt_PlanningBOMNextLevel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_PlanningBOMNextLevelSp(
			int? Level,
			string Item,
			string Orig_Item,
			DateTime? EffectiveDate,
			int? IndentedLevelView,
			int? ShowPrice,
			int? TErr)
		{
			IntType _Level = Level;
			ItemType _Item = Item;
			ItemType _Orig_Item = Orig_Item;
			DateType _EffectiveDate = EffectiveDate;
			ListYesNoType _IndentedLevelView = IndentedLevelView;
			ListYesNoType _ShowPrice = ShowPrice;
			ListYesNoType _TErr = TErr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PlanningBOMNextLevelSp";
				
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Orig_Item", _Orig_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IndentedLevelView", _IndentedLevelView, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPrice", _ShowPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TErr", _TErr, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
