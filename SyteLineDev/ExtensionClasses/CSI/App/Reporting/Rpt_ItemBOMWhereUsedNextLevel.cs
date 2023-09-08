//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemBOMWhereUsedNextLevel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ItemBOMWhereUsedNextLevel : IRpt_ItemBOMWhereUsedNextLevel
	{
		readonly IApplicationDB appDB;
		
		public Rpt_ItemBOMWhereUsedNextLevel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_ItemBOMWhereUsedNextLevelSp(
			int? Level,
			string TJobType,
			string History,
			string Item,
			string Orig_Item,
			DateTime? EffectiveDate,
			int? IndentedLevelView,
			int? TErr)
		{
			IntType _Level = Level;
			LongListType _TJobType = TJobType;
			LongListType _History = History;
			ItemType _Item = Item;
			ItemType _Orig_Item = Orig_Item;
			GenericDateType _EffectiveDate = EffectiveDate;
			FlagNyType _IndentedLevelView = IndentedLevelView;
			FlagNyType _TErr = TErr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemBOMWhereUsedNextLevelSp";
				
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TJobType", _TJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "History", _History, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Orig_Item", _Orig_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IndentedLevelView", _IndentedLevelView, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TErr", _TErr, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
