//PROJECT NAME: Codes
//CLASS NAME: ICustSpecificUnitPriceExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICustSpecificUnitPriceExists
	{
		(int? ReturnCode,
		int? CustSpecificUnitPriceExists,
		string Infobar) CustSpecificUnitPriceExistsSp(
			string CurrCode,
			string CustNum,
			string Item,
			int? CustSpecificUnitPriceExists,
			string Infobar);
	}
}

