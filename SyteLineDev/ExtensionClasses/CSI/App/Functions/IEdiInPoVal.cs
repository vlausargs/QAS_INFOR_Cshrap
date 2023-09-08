//PROJECT NAME: Data
//CLASS NAME: IEdiInPoVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInPoVal
	{
		int? EdiInPoValSP(
			Guid? EdiVinvRowPointer,
			Guid? VendTpRowPointer,
			string lrStat,
			string CallFrom);
	}
}

