//PROJECT NAME: Data
//CLASS NAME: IFSBBPActual.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFSBBPActual
	{
		decimal? FSBBPActualFn(
			string FSBName,
			DateTime? PerStart,
			DateTime? PerEnd,
			string ChartType,
			string Acct,
			string UC1,
			string UC2,
			string UC3,
			string UC4);
	}
}

