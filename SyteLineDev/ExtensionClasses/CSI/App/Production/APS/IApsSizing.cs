//PROJECT NAME: Production
//CLASS NAME: IApsSizing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSizing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ApsSizingSp(
			int? AltNo = 0);
	}
}

