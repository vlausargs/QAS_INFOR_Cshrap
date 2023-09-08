//PROJECT NAME: Data
//CLASS NAME: IUpdateCoNumonDemandingPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateCoNumonDemandingPo
	{
		int? UpdateCoNumonDemandingPoSp(
			string PoNum,
			string PoSourceSiteCoNum);
	}
}

