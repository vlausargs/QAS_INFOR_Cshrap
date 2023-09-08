//PROJECT NAME: Logistics
//CLASS NAME: IProfileRMACreditMemo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IProfileRMACreditMemo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileRMACreditMemoSp(string BCrmNum = null,
		string ECrmNum = null,
		DateTime? BCrmDate = null,
		DateTime? ECrmDate = null);
	}
}

