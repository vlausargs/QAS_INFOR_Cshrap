//PROJECT NAME: Production
//CLASS NAME: IProjPckHdrsDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjPckHdrsDelete
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ProjPckHdrsDeleteSp(int? BegPackNum,
		int? EndPackNum,
		int? ListOpts,
		string Infobar,
		string FilterString);
	}
}

