//PROJECT NAME: Finance
//CLASS NAME: ICHSGetListOfBanks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetListOfBanks
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSGetListOfBanksSp(string UserName,
		string UserGroup,
		string BackCodeFilter = null);
	}
}

