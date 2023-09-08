//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ARDraftPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ARDraftPosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARDraftPostingSp(int? PDisplayDetail = null,
			string PStartingCustomer = null,
			string PEndingCustomer = null,
			string pStartingBankCode = null,
			string pEndingBankCode = null,
			DateTime? pStartingDueDate = null,
			DateTime? pEndingDueDate = null,
			int? pStartingDraftNumber = null,
			int? pEndingDraftNumber = null,
			int? PDisplayHeader = null,
			string PSessionIDChar = null,
			string pSite = null,
			string BGUser = null);
	}
}

