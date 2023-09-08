//PROJECT NAME: Data
//CLASS NAME: ILcapGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILcapGen
	{
		(int? ReturnCode,
			string Infobar) LcapGenSp(
			Guid? ProcessId,
			string VendNum,
			DateTime? InvoiceDate,
			DateTime? GLDistDate,
			string VendorInvoice,
			decimal? AmtDuty,
			decimal? AmtFreight,
			decimal? AmtBrokerage,
			decimal? AmtInsurance,
			decimal? AmtLocFreight,
			string CurPoNum,
			string Infobar);
	}
}

