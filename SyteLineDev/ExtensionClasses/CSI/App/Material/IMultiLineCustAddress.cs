//PROJECT NAME: Finance
//CLASS NAME: IMultiLineCustAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiLineCustAddress
	{
		string MultiLineCustAddressSp(
			int? ContactNum,
			string CustNum,
			int? CustSeq);
	}
}

