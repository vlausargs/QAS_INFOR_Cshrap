//PROJECT NAME: Logistics
//CLASS NAME: IBArpmtd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IBArpmtd
	{
		(int? ReturnCode, string Infobar) BArpmtdSp(Guid? PRecid,
		string Infobar);
	}
}

