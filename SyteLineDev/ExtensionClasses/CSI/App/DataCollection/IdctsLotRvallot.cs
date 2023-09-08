//PROJECT NAME: DataCollection
//CLASS NAME: IdctsLotRvallot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IdctsLotRvallot
	{
		(int? ReturnCode, string Infobar) dctsLotRvallotSp(string Item,
		string Lot,
		string RemoteSiteLot,
		string Infobar,
		string Site = null);
	}
}

