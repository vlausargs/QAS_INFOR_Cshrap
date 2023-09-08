//PROJECT NAME: Production
//CLASS NAME: IApsSyncParameters.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncParameters
	{
		int? ApsSyncParametersSp();
	}
}

