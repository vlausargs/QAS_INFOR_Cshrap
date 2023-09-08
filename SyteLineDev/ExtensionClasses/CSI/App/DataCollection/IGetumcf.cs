//PROJECT NAME: DataCollection
//CLASS NAME: IGetumcf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IGetumcf
	{
		(int? ReturnCode, decimal? ConvFactor,
		string Infobar) GetumcfSp(string OtherUM,
		string Item,
		string VendNum,
		string Area,
		decimal? ConvFactor,
		string Infobar,
		string Site = null);


        decimal? GetumcfFn(
            string OtherUM,
            string Item,
            string VendNum,
            string Area);
    }

}

