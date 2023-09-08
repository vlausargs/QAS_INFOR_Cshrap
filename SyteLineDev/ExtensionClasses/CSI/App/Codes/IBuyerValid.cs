//PROJECT NAME: Codes
//CLASS NAME: IBuyerValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IBuyerValid
	{
		(int? ReturnCode,
		string Infobar) BuyerValidSp(
			string Buyer,
			string Infobar);
	}
}

