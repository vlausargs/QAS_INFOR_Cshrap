//PROJECT NAME: Data
//CLASS NAME: IEstimateLinesGetItemCustItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEstimateLinesGetItemCustItem
	{
		(int? ReturnCode,
			int? PEnableUM) EstimateLinesGetItemCustItemSp(
			string PItem,
			int? PEnableUM);
	}
}

