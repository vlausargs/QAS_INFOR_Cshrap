//PROJECT NAME: Finance
//CLASS NAME: IPortal_CCILogCard.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_CCILogCard
	{
		int? Portal_CCILogCardSp(string CardNum,
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

