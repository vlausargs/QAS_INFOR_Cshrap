//PROJECT NAME: Logistics
//CLASS NAME: IUomConvAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUomConvAmt
	{
		(int? ReturnCode, decimal? ConvertedAmt,
		string Infobar) UomConvAmtSp(decimal? AmtToBeConverted,
		decimal? UomConvFactor,
		string FROMBase,
		decimal? ConvertedAmt,
		string Infobar);

        decimal? UomConvAmtFn(decimal? AmtToBeConverted,
        decimal? UomConvFactor,
        string FromBase);
    }
}

