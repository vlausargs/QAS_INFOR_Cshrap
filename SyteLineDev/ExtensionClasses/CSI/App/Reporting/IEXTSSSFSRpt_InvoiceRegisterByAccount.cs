//PROJECT NAME: Reporting
//CLASS NAME: IEXTSSSFSRpt_InvoiceRegisterByAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IEXTSSSFSRpt_InvoiceRegisterByAccount
	{
		ICollectionLoadResponse EXTSSSFSRpt_InvoiceRegisterByAccountFn(
			string AccountStarting,
			string AccountEnding,
			string InvNumStarting,
			string InvNumEnding,
			DateTime? InvoiceDateStarting,
			DateTime? InvoiceDateEnding,
			string SSSFSSROStarting,
			string SSSFSSROEnding,
			string SSSFSContractStarting,
			string SSSFSContractEnding,
			string CustomerStarting,
			string CustomerEnding,
			string StateStarting,
			string StateEnding,
			string ItemStarting,
			string ItemEnding,
			int? TranslateToDomestic,
			int? ShowPrice,
			string TInvSourceSel);
	}
}

