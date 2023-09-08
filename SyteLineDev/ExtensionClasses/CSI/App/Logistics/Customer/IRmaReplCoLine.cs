//PROJECT NAME: Logistics
//CLASS NAME: IRmaReplCoLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaReplCoLine
	{
		(int? ReturnCode, decimal? RUnitPrice,
		string Infobar) RmaReplCoLineSp(string PRmaNum,
		int? PRmaLine,
		string PCoNum,
		int? PCoLine,
		string PItem,
		decimal? RUnitPrice,
		string Infobar);
	}
}

