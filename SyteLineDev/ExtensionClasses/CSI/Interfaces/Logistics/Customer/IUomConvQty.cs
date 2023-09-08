//PROJECT NAME: Logistics
//CLASS NAME: IUomConvQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUomConvQty
	{
		(int? ReturnCode, decimal? ConvertedQty,
		string Infobar) UomConvQtySp(decimal? QtyToBeConverted,
		decimal? UomConvFactor,
		string FROMBase,
		decimal? ConvertedQty,
		string Infobar);

        decimal? UomConvQtyFn(decimal? QtyToBeConverted,
        decimal? UomConvFactor,
        string FromBase);
    }
}

