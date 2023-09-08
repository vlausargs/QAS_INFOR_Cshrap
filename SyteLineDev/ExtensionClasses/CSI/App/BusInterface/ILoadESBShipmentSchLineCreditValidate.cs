//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBShipmentSchLineCreditValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBShipmentSchLineCreditValidate
	{
		(int? ReturnCode,
			string Infobar) LoadESBShipmentSchLineCreditValidateSp(
			string CoNum,
			decimal? CobPrice,
			decimal? CoItemQuantity,
			int? CoLine,
			int? CoItemRelease,
			string CobItem,
			string TaxCode1,
			string TaxCode2,
			string CustNum,
			string CoOrigSite,
			string Infobar);
	}
}

