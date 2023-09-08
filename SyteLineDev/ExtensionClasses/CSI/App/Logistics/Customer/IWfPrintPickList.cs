//PROJECT NAME: Logistics
//CLASS NAME: IWfPrintPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IWfPrintPickList
	{
		(int? ReturnCode, string Infobar) WfPrintPickListSp(string pSite,
		string pCoNum,
		string Infobar);
	}
}

