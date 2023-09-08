//PROJECT NAME: Production
//CLASS NAME: IProjPckHdrsLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjPckHdrsLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProjPckHdrsLoadSp(string PackNumFilter = null);
	}
}

