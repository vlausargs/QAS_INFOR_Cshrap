//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBServiceMaterialGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBServiceMaterialGroup
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBServiceMaterialGroupSp(string SroNum,
		int? SroLine,
		int? SroOper);
	}
}

