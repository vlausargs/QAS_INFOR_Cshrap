//PROJECT NAME: Data
//CLASS NAME: ITaxSumR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITaxSumR
	{
		int? TaxSumRSp(
			Guid? InvHdrRowPointer,
			int? TransDomCurr);
	}
}

