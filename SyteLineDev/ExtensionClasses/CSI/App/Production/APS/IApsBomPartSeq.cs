//PROJECT NAME: Production
//CLASS NAME: IApsBomPartSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBomPartSeq
	{
		int? ApsBomPartSeqFn(
			int? POperNum,
			int? PAltGroup,
			int? PAltGroupRank);
	}
}

