//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBProjectMasterLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBProjectMasterLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBProjectMasterLineSp(string ProjNum,
		int? ProjTask);
	}
}

