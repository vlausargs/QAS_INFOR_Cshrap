//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TaxInvoicedParametric.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TaxInvoicedParametric
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxInvoicedParametricSP(int? taxsystem = null,
		string taxjur = null,
		DateTime? Begininvstaxinvdate = null,
		DateTime? Endinvstaxinvdate = null,
		int? BegininvstaxinvdateOffset = null,
		int? EndinvstaxinvdateOffset = null,
		int? Showdetail = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

