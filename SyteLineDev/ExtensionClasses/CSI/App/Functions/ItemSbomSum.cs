//PROJECT NAME: Data
//CLASS NAME: ItemSbomSum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemSbomSum : IItemSbomSum
	{
		readonly IApplicationDB appDB;
		
		public ItemSbomSum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ItemSbomSumSp(
			string CurItem,
			string Infobar,
			int? FromTemp = null,
			int? FromJobmatlTemp = null)
		{
			ItemType _CurItem = CurItem;
			InfobarType _Infobar = Infobar;
			IntType _FromTemp = FromTemp;
			ListYesNoType _FromJobmatlTemp = FromJobmatlTemp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemSbomSumSp";
				
				appDB.AddCommandParameter(cmd, "CurItem", _CurItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromTemp", _FromTemp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobmatlTemp", _FromJobmatlTemp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
