//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_UnifiedTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_UnifiedTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_UnifiedTransactionSp(string beg_partner_id,
		DateTime? beg_trans_date,
		string beg_sro_num,
		string end_partner_id,
		DateTime? end_trans_date,
		string end_sro_num,
		string RefType,
		int? IncludeMaterial,
		int? IncludeMaterialNotes,
		int? IncludeLabor,
		int? IncludeLaborNotes,
		int? IncludeMisc,
		int? IncludeMiscNotes,
		int? PageBreak,
		int? ShowPosted,
		int? ShowUnPosted,
		int? ShowInternal,
		int? ShowExternal,
		string pSite = null);
	}
}

