//PROJECT NAME: Codes
//CLASS NAME: IGetISOCountryInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetISOCountryInfo
	{
		(int? ReturnCode,
		string ISOCountryCode) GetISOCountryInfoSp(
			string ISOCountry,
			string ISOCountryCode = null);
	}
}

