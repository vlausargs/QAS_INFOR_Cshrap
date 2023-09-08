//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetSROCustItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetSROCustItem
	{
		string SSSFSGetSROCustItemFn(
			string CustNum,
			string SRONum,
			string Item,
			string CustItem = null);
	}
}

