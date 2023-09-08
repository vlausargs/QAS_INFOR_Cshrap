//PROJECT NAME: Production
//CLASS NAME: IWBSReturnProjectType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IWBSReturnProjectType
	{
		string WBSReturnProjectTypeFn(
			string RefType,
			string RefNum);
	}
}

