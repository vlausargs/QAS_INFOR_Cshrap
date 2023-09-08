//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBServiceOtherGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBServiceOtherGroup
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBServiceOtherGroupSp(string SroNum,
		int? SroLine,
		int? SroOper);
	}
}

