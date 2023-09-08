//PROJECT NAME: Codes
//CLASS NAME: IGetCurrDecimalPlaces.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetCurrDecimalPlaces
	{
		(int? ReturnCode, int? DecimalPlaces,
		string Infobar) GetCurrDecimalPlacesSp(string CurrCode,
		int? DecimalPlaces,
		string Infobar);
	}
}

