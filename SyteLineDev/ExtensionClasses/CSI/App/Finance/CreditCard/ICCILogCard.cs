//PROJECT NAME: Finance
//CLASS NAME: ICCILogCard.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ICCILogCard
	{
		int? CCILogCardSp(
			string CardNum,
			string CardSystem,
			string CustNum,
			int? CustSeq,
			string expDate,
			string NameOnCard,
			decimal? GatewayTransNum,
			string CardType,
			string Username = null,
			string CardSystemId = null);
	}
}

