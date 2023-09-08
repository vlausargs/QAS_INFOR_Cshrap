//PROJECT NAME: Finance
//CLASS NAME: IMXGetInvTaxCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXGetInvTaxCode
	{
		string MXGetInvTaxCodeFn(
			string InvNum);
	}
}

