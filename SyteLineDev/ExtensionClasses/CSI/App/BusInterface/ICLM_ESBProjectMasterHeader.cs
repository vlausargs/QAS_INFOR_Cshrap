//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBProjectMasterHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBProjectMasterHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBProjectMasterHeaderSp(string ProjNum);
	}
}

