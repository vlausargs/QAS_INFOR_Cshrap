//PROJECT NAME: Data
//CLASS NAME: IJobBFlushO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobBFlushO
	{
		(int? ReturnCode,
			string Infobar) JobBFlushOSp(
			decimal? PQtyComplete,
			decimal? PQtyScrapped,
			string PBflushSetup,
			Guid? pJobTranRP,
			Guid? pJobRouteRp,
			string Infobar);
	}
}

