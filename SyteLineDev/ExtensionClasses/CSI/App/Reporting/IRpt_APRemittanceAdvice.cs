//PROJECT NAME: Reporting
//CLASS NAME: IRpt_APRemittanceAdvice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_APRemittanceAdvice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_APRemittanceAdviceSp(string PSessionIDChar = null,
		string PSortNameNum = "Number",
		string PPayType = null,
		string PBankCode = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		string pSite = null);
	}
}

