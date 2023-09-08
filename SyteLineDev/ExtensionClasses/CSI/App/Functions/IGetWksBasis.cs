//PROJECT NAME: Data
//CLASS NAME: IGetWksBasis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetWksBasis
	{
		string GetWksBasisFn(
			string CoNum);
	}
}

