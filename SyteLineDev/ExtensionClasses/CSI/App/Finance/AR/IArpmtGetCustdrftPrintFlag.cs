//PROJECT NAME: Finance
//CLASS NAME: IArpmtGetCustdrftPrintFlag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtGetCustdrftPrintFlag
	{
		int? ArpmtGetCustdrftPrintFlagFn(
			int? PDraftNum);
	}
}

