//PROJECT NAME: Data
//CLASS NAME: IGetKPICategories.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetKPICategories
	{
		string GetKPICategoriesFn(
			int? KPINum);
	}
}

