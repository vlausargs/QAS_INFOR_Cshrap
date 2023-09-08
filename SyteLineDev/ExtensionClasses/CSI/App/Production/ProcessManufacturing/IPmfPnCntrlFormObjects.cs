//PROJECT NAME: Production
//CLASS NAME: IPmfPnCntrlFormObjects.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnCntrlFormObjects
	{
		(int? ReturnCode,
			int? hide_check_box,
			int? no_select_qty_ord) PmfPnCntrlFormObjectsSp(
			Guid? mf_spec_rp,
			int? pn_size_method,
			int? hide_check_box,
			int? no_select_qty_ord);
	}
}

