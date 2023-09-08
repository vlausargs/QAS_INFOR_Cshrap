//PROJECT NAME: Finance
//CLASS NAME: IDeleteDimension.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IDeleteDimension
	{
		int? DeleteDimensionSp(
			string ObjectName,
			string Dimension);
	}
}

