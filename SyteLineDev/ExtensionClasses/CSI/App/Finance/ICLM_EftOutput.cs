//PROJECT NAME: Finance
//CLASS NAME: ICLM_EftOutput.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_EftOutput
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_EftOutputSp(DateTime? PEftFileDate,
		string BankCode = null);
	}
}

