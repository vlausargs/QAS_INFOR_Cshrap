//PROJECT NAME: Production
//CLASS NAME: IApsDeriveJobSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsDeriveJob
	{
		string ApsDeriveJobSp(
			string OrderTable,
			int? PSuffix,
			string PJobType,
			string PJobJob,
			string PsNum,
			string OrderId,
			string PJobItemJob,
			int? OrdType);
	}
}

