//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsJobItemData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsJobItemData
	{
		(int? ReturnCode,
		int? ItemPlanFlag) CurrentMaterialsJobItemDataSp(
			string Item,
			int? ItemPlanFlag);
	}
}

