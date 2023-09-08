//PROJECT NAME: Production
//CLASS NAME: IJobrouteExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobrouteExists
	{
		(int? ReturnCode, int? JobrouteExists) JobrouteExistsSp(string Job,
		int? Suffix,
		int? JobrouteExists);

		int? JobrouteExistsFn(
			string Job,
			int? Suffix);
	}
}

