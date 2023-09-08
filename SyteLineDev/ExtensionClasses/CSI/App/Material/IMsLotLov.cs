//PROJECT NAME: Material
//CLASS NAME: IMsLotLov.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMsLotLov
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MsLotLovSp(string PItem,
		string PTrnLoc,
		string PWhse,
		int? UseSite = 0,
		string Site = null);
	}
}

