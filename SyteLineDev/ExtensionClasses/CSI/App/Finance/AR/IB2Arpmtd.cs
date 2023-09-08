//PROJECT NAME: Finance
//CLASS NAME: IB2Arpmtd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IB2Arpmtd
	{
		(int? ReturnCode,
			decimal? POpenBal,
			int? PFixedRate) B2ArpmtdSp(
			Guid? PRecid,
			decimal? POpenBal,
			int? PFixedRate);
	}
}

