//PROJECT NAME: Logistics
//CLASS NAME: IItemFeatureCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IItemFeatureCheck
	{
		(int? ReturnCode, string NewItem,
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
		string Site = null);
	}
}

