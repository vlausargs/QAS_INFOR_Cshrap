//PROJECT NAME: Logistics
//CLASS NAME: IPP_ValEstimateWBSource.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPP_ValEstimateWBSource
	{
		(int? ReturnCode, string Infobar) PP_ValEstimateWBSourceSp(string QuoteMethod,
		string QuoteType,
		string Source,
		int? SourceLine,
		string Infobar);
	}
}

