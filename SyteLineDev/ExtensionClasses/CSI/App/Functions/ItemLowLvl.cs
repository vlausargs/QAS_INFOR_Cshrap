//PROJECT NAME: Data
//CLASS NAME: ItemLowLvl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemLowLvl : IItemLowLvl
	{
		readonly IApplicationDB appDB;
		
		public ItemLowLvl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Sequence,
			string Infobar) ItemLowLvlSp(
			int? LowLevel,
			string Job,
			int? Suffix,
			int? ListAfter,
			int? FromItemLow,
			string RootItem,
			int? Sequence,
			string Infobar)
		{
			LowLevelType _LowLevel = LowLevel;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ListYesNoType _ListAfter = ListAfter;
			ListYesNoType _FromItemLow = FromItemLow;
			ItemType _RootItem = RootItem;
			IntType _Sequence = Sequence;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLowLvlSp";
				
				appDB.AddCommandParameter(cmd, "LowLevel", _LowLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ListAfter", _ListAfter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItemLow", _FromItemLow, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootItem", _RootItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Sequence = _Sequence;
				Infobar = _Infobar;
				
				return (Severity, Sequence, Infobar);
			}
		}
	}
}
