//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBItemCategory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBItemCategory
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBItemCategorySp(
			string item);
	}
}

