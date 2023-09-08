//PROJECT NAME: Logistics
//CLASS NAME: IRmaItemCloseHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaItemCloseHeader
	{
		(int? ReturnCode, string Infobar) RmaItemCloseHeaderSp(string PRmaNum,
		string Infobar);
	}
}

