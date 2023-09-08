//PROJECT NAME: Data
//CLASS NAME: IARDistribDomAmts2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARDistribDomAmts2
	{
		(int? ReturnCode,
			decimal? pOpenBal,
			int? pFixedRate) ARDistribDomAmts2Sp(
			string pSite,
			Guid? pRowPointer,
			decimal? pOpenBal,
			int? pFixedRate);
	}
}

