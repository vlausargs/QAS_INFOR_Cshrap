//PROJECT NAME: Logistics
//CLASS NAME: IRpt_TaxPayable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IRpt_TaxPayable
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxPayableSp(DateTime? PDistDateStarting,
		DateTime? PDistDateEnding,
		string PTaxCodeStarting,
		string PTaxCodeEnding,
		string PVendorStarting,
		string PVendorEnding,
		string PSite = null);
	}
}

