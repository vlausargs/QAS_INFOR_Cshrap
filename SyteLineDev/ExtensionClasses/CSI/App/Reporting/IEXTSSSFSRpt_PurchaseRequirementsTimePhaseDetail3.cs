//PROJECT NAME: Reporting
//CLASS NAME: IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3
	{
		(int? ReturnCode,
			string t_stat,
			decimal? t_req,
			string t_ref,
			string t_name,
			int? t_sroitem_row_idx,
			decimal? t_on_hand,
			DateTime? t_sro_date) EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3Sp(
			string t_stat,
			decimal? t_req,
			string t_ref,
			string t_name,
			int? t_sroitem_row_idx,
			decimal? t_on_hand,
			DateTime? t_sro_date);
	}
}

