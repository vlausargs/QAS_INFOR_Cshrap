//PROJECT NAME: Logistics
//CLASS NAME: ICheckItemCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICheckItemCost
	{
		(int? ReturnCode,
		string PromptMsg,
		string PromptButtons) CheckItemCostSp(
			string PItem,
			string PWhse,
			string PromptMsg,
			string PromptButtons);
	}
}

