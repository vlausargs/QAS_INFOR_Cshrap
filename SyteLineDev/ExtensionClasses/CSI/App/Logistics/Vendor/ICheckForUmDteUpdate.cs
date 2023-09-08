//PROJECT NAME: Logistics
//CLASS NAME: ICheckForUmDteUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICheckForUmDteUpdate
	{
		(int? ReturnCode, string PNewUM,
		DateTime? PNewDte,
		string PromptMsg,
		string PromptButtons) CheckForUmDteUpdateSp(string PReqNum,
		string PVendNum,
		string POldVendNum,
		string PItem,
		string PUM,
		DateTime? PDueDate,
		string PRefType,
		string PNewUM,
		DateTime? PNewDte,
		string PromptMsg,
		string PromptButtons);
	}
}

