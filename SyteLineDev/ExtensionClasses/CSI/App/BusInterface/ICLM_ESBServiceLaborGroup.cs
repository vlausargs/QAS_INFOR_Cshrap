//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBServiceLaborGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBServiceLaborGroup
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBServiceLaborGroupSp(string SroNum,
		int? SroLine,
		int? SroOper);
	}
}

