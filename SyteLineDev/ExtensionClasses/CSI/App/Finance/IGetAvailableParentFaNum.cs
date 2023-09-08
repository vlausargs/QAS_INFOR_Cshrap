//PROJECT NAME: Finance
//CLASS NAME: IGetAvailableParentFaNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetAvailableParentFaNum
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetAvailableParentFaNumSp(string FaNum);
	}
}

