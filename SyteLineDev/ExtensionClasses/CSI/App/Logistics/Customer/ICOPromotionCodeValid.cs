//PROJECT NAME: Logistics
//CLASS NAME: ICOPromotionCodeValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICOPromotionCodeValid
	{
		(int? ReturnCode, string Infobar) COPromotionCodeValidSp(string Slsman = null,
		string CustNum = null,
		string EndUserType = null,
		DateTime? CoOrderDate = null,
		string CurrCode = null,
		string CoNum = null,
		int? CustSeq = null,
		string CorpCust = null,
		string Infobar = null);
	}
}

