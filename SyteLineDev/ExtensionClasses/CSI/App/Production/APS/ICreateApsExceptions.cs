//PROJECT NAME: Production
//CLASS NAME: ICreateApsExceptions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICreateApsExceptions
	{
		int? CreateApsExceptionsSp();
	}
}

