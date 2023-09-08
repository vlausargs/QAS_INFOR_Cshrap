//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBAssignmentGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBAssignmentGroup
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBAssignmentGroupSp(string SroNum,
		int? SroLine,
		int? SroOper);
	}
}

