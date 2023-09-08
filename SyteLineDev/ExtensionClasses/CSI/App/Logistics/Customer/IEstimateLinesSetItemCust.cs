//PROJECT NAME: Logistics
//CLASS NAME: IEstimateLinesSetItemCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstimateLinesSetItemCust
	{
		int? EstimateLinesSetItemCustSp(int? PSetItemCust,
		string PItem,
		string PCustNum,
		string PCustItem,
		decimal? PCostConv,
		string PCoNum,
		string PUM);
	}
}

