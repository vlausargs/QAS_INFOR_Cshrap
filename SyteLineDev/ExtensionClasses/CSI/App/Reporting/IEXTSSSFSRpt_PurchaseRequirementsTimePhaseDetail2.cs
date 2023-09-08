//PROJECT NAME: Reporting
//CLASS NAME: IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2
	{
		(int? ReturnCode,
			DateTime? t_sro_date,
			int? t_sroitem_row_idx) EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2Sp(
			string iItem,
			string iWhseStarting,
			string iWhseEnding,
			int? iShowDepl,
			DateTime? t_sro_date,
			int? t_sroitem_row_idx);
	}
}

