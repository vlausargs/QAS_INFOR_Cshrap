//PROJECT NAME: Data
//CLASS NAME: IBPActual.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBPActual
	{
		decimal? BPActualFn(
			DateTime? PerStart,
			DateTime? PerEnd,
			string ChartType,
			string Hierarchy,
			string Acct,
			string UC1,
			string UC2,
			string UC3,
			string UC4);
	}
}

