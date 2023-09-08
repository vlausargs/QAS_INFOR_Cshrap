//PROJECT NAME: Logistics
//CLASS NAME: IPoLineRelease.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoLineRelease
	{
		(int? ReturnCode, int? PoLine,
		int? PoRelease,
		string Infobar) PoLineReleaseSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		string Infobar);
	}
}

