//PROJECT NAME: CSIMaterial
//CLASS NAME: LotAddPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ILotAddPre
	{
		(int? ReturnCode, string PromptMsg, string PromptButtons) LotAddPreSp(string Item,
		string Lot,
		string PromptMsg,
		string PromptButtons,
		string Site = null);
	}
	
	public class LotAddPre : ILotAddPre
	{
		readonly IApplicationDB appDB;
		
		public LotAddPre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg, string PromptButtons) LotAddPreSp(string Item,
		string Lot,
		string PromptMsg,
		string PromptButtons,
		string Site = null)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LotAddPreSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PromptMsg, PromptButtons);
			}
		}
	}
}
