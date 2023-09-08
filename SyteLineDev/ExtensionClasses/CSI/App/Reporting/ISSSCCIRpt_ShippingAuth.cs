//PROJECT NAME: Reporting
//CLASS NAME: ISSSCCIRpt_ShippingAuth.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSCCIRpt_ShippingAuth
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSCCIRpt_ShippingAuthSp(Guid? BatchId,
		string GenerateReport,
		string pSite = null);
	}
}

