//PROJECT NAME: Data
//CLASS NAME: IsStdItemBOM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsStdItemBOM : IIsStdItemBOM
	{
		readonly IApplicationDB appDB;
		
		public IsStdItemBOM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsStdItemBOMFn(
			string Item,
			int? Suffix)
		{
			ItemType _Item = Item;
			SuffixType _Suffix = Suffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsStdItemBOM](@Item, @Suffix)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
