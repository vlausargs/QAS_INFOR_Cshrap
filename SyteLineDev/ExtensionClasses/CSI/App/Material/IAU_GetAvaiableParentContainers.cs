//PROJECT NAME: Material
//CLASS NAME: IAU_GetAvaiableParentContainers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IAU_GetAvaiableParentContainers
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) AU_GetAvaiableParentContainersSp(
			string ContainerNum,
			string Whse,
			string Loc);
	}
}

