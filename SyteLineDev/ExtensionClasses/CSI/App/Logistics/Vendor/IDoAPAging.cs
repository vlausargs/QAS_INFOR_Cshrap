//PROJECT NAME: Logistics.Vendor
//CLASS NAME: IDoAPAging.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IDoAPAging
	{
		(int? ReturnCode,
			string PAgeDesc1,
			string PAgeDesc2,
			string PAgeDesc3,
			string PAgeDesc4,
			string PAgeDesc5,
			decimal? PAgeBal1,
			decimal? PAgeBal2,
			decimal? PAgeBal3,
			decimal? PAgeBal4,
			decimal? PAgeBal5,
			decimal? PAgeBal6,
			string Infobar) DoAPAgingSp(
			string PVendNum,
			string PCurrCode,
			int? PTransDom,
			string PSite,
			string PAgeDesc1,
			string PAgeDesc2,
			string PAgeDesc3,
			string PAgeDesc4,
			string PAgeDesc5,
			decimal? PAgeBal1,
			decimal? PAgeBal2,
			decimal? PAgeBal3,
			decimal? PAgeBal4,
			decimal? PAgeBal5,
			decimal? PAgeBal6,
			string Infobar);
	}
}

