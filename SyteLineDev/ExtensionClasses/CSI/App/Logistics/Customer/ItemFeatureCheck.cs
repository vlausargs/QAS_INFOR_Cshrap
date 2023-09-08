//PROJECT NAME: Logistics
//CLASS NAME: ItemFeatureCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ItemFeatureCheck : IItemFeatureCheck
	{
		readonly IApplicationDB appDB;
		
		
		public ItemFeatureCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string NewItem,
		string InvparmsCreateFeat,
		string CreateItemMsg,
		string CreateItemButtons,
		string Infobar,
		string ItemDesc) ItemFeatureCheckSp(string FeatStr,
		string PlanningItem,
		string FeatQtys,
		string NewItem,
		string InvparmsCreateFeat,
		string CreateItemMsg,
		string CreateItemButtons,
		string Infobar,
		string ItemDesc,
		string Site = null)
		{
			FeatStrType _FeatStr = FeatStr;
			ItemType _PlanningItem = PlanningItem;
			LongListType _FeatQtys = FeatQtys;
			ItemType _NewItem = NewItem;
			CreateFeatType _InvparmsCreateFeat = InvparmsCreateFeat;
			Infobar _CreateItemMsg = CreateItemMsg;
			Infobar _CreateItemButtons = CreateItemButtons;
			InfobarType _Infobar = Infobar;
			DescriptionType _ItemDesc = ItemDesc;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemFeatureCheckSp";
				
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanningItem", _PlanningItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatQtys", _FeatQtys, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewItem", _NewItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvparmsCreateFeat", _InvparmsCreateFeat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateItemMsg", _CreateItemMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateItemButtons", _CreateItemButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewItem = _NewItem;
				InvparmsCreateFeat = _InvparmsCreateFeat;
				CreateItemMsg = _CreateItemMsg;
				CreateItemButtons = _CreateItemButtons;
				Infobar = _Infobar;
				ItemDesc = _ItemDesc;
				
				return (Severity, NewItem, InvparmsCreateFeat, CreateItemMsg, CreateItemButtons, Infobar, ItemDesc);
			}
		}
	}
}
