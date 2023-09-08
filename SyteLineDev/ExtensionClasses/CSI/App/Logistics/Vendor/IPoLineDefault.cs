//PROJECT NAME: Logistics
//CLASS NAME: IPoLineDefault.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoLineDefault
	{
		(int? ReturnCode, string Stat,
		DateTime? OrderDate,
		string VendNum,
		string VendorName,
		string VendOrder,
		string CurrCode,
		decimal? PoExchRate,
		string Whse,
		string PoTaxCode1,
		string PoTaxCode2,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		string EcCode,
		int? FirstLine,
		int? PoChgNum,
		DateTime? PoChgDate,
		string PoChgStat,
		string CurrAmtTotFormat,
		string CurrCstPrcFormat,
		string Infobar,
		string CurrAmtFormat) PoLineDefaultSp(string PoNum,
		string PoType,
		string Stat,
		DateTime? OrderDate,
		string VendNum,
		string VendorName,
		string VendOrder,
		string CurrCode,
		decimal? PoExchRate,
		string Whse,
		string PoTaxCode1,
		string PoTaxCode2,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		string EcCode,
		int? FirstLine,
		int? PoChgNum,
		DateTime? PoChgDate,
		string PoChgStat,
		string CurrAmtTotFormat,
		string CurrCstPrcFormat,
		string Infobar,
		string CurrAmtFormat = null);
	}
}

