//PROJECT NAME: Logistics
//CLASS NAME: IPOBuilderCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPOBuilderCreate
	{
		(int? ReturnCode,
			string Infobar) POBuilderCreateSp(
			string OriginatingSite,
			Guid? ProcessID,
			string Vendor,
			DateTime? Date,
			string PoType,
			string Status,
			string CreateAs,
			int? IncludeTaxInCost,
			string BuilderPONumber,
			string TermsCode,
			string Infobar,
			int? AutoVoucher);
	}
}

