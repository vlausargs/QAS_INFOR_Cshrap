//PROJECT NAME: Data
//CLASS NAME: FindDescOfInvItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FindDescOfInvItem : IFindDescOfInvItem
	{
		readonly IApplicationDB appDB;
		
		public FindDescOfInvItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FindDescOfInvItemFn(
			string TCoNum,
			int? TCoLine,
			int? TCoRelease,
			string TItem)
		{
			CoNumType _TCoNum = TCoNum;
			CoLineType _TCoLine = TCoLine;
			CoReleaseType _TCoRelease = TCoRelease;
			ItemType _TItem = TItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FindDescOfInvItem](@TCoNum, @TCoLine, @TCoRelease, @TItem)";
				
				appDB.AddCommandParameter(cmd, "TCoNum", _TCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoLine", _TCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoRelease", _TCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
