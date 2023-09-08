//PROJECT NAME: POS
//CLASS NAME: ISSSPOSGetPartnerName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSGetPartnerName
	{
		string SSSPOSGetPartnerNameFn(
			string PartnerId,
			string UserName);
	}
}

