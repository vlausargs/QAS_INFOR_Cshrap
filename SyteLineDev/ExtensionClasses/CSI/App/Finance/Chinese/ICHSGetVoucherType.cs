//PROJECT NAME: Finance
//CLASS NAME: ICHSGetVoucherType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetVoucherType
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CHSGetVoucherTypeSp(string UserName,
		string UserGroup,
		string Infobar);
	}
}

