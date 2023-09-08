//PROJECT NAME: Logistics
//CLASS NAME: IAptrxpSumm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAptrxpSumm
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) AptrxpSummSp(string VendNum,
		int? SiteFlag,
		int? ActiveFlag,
		string Filter = null,
		string Infobar = null,
		string SiteGroup = null);
	}
}

