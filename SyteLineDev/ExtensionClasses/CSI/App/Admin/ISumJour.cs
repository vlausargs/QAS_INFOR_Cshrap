//PROJECT NAME: Admin
//CLASS NAME: ISumJour.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ISumJour
	{
		int? SumJourSp(string Id,
		int? Repair);
	}
}

