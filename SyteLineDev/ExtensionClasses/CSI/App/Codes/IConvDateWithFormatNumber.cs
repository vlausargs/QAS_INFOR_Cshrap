//PROJECT NAME: Codes
//CLASS NAME: IConvDateWithFormatNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IConvDateWithFormatNumber
	{
		(int? ReturnCode, DateTime? rDate) ConvDateWithFormatNumberSp(int? pDateFormatNumber,
		string pDate,
		DateTime? rDate);

		string ConvDateWithFormatNumberFn(
			int? pDateFormatNumber,
			string pDate);
	}
}

