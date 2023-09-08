//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobCoProduct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobCoProduct
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobCoProductSp(string Job = null,
		int? Suffix = null,
		string pSite = null);
	}
}

