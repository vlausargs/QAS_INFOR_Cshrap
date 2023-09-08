//PROJECT NAME: Logistics
//CLASS NAME: IBAppmtd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IBAppmtd
	{
		(int? ReturnCode, string Infobar) BAppmtdSp(Guid? PRecid,
		string Infobar);
	}
}

