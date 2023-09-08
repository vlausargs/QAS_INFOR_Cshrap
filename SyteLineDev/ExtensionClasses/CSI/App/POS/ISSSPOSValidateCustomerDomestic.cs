//PROJECT NAME: POS
//CLASS NAME: ISSSPOSValidateCustomerDomestic.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSValidateCustomerDomestic
	{
		(int? ReturnCode, string Infobar) SSSPOSValidateCustomerDomesticSp(string CustNum,
		string Infobar);
	}
}

