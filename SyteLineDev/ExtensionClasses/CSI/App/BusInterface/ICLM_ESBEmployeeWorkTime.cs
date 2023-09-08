//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBEmployeeWorkTime.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBEmployeeWorkTime
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBEmployeeWorkTimeSp(string DocumentType,
		decimal? TransNum);
	}
}

