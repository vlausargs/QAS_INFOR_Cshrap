//PROJECT NAME: Material
//CLASS NAME: IBflushLocRequiredSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IBflushLocRequired
	{
		int? BflushLocRequiredSp(
			string Item,
			string WC);
	}
}

