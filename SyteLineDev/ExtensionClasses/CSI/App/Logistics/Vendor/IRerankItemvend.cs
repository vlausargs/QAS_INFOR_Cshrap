//PROJECT NAME: Logistics
//CLASS NAME: IRerankItemvend.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IRerankItemvend
	{
		(int? ReturnCode, string Infobar) RerankItemvendSp(string PItem,
		string Infobar);
	}
}

