//PROJECT NAME: Logistics
//CLASS NAME: IPOBuilder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPOBuilder
	{
		(int? ReturnCode, string BuilderPONumber,
		string Infobar) POBuilderSP(Guid? ProcessID,
		string Vendor,
		DateTime? Date,
		string POType,
		string Status,
		string CreateAs,
		int? IncludeTaxInCost,
		string TermsCode,
		string BuilderPONumber,
		string Infobar,
		int? AutoVoucher);
	}
}

