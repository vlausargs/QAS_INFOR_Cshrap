//PROJECT NAME: Logistics
//CLASS NAME: IPoPreDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoPreDelete
	{
		(int? ReturnCode, string Infobar) PoPreDeleteSp(string PoNum,
		string Stat,
		string Infobar);
	}
}

