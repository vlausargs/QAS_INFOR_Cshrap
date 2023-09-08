//PROJECT NAME: Codes
//CLASS NAME: IGetISOCurrencyInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetISOCurrencyInfo
	{
		(int? ReturnCode,
		string ISODescription) GetISOCurrencyInfoSp(
			string ISOCurrCode,
			string ISODescription = null);
	}
}

