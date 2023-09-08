//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_SPCSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_SPCSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_SPCSSRSSp(string i_item,
		string i_ref_type,
		string i_entity,
		int? i_lookback,
		int? i_showdetail,
		string psite);
	}
}

