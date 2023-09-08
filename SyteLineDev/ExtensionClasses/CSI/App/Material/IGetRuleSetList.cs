//PROJECT NAME: Material
//CLASS NAME: IGetRuleSetList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetRuleSetList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetRuleSetListSp(string RSList);
	}
}

