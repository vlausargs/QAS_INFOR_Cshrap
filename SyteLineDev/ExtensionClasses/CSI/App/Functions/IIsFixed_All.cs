//PROJECT NAME: Data
//CLASS NAME: IIsFixed_All.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsFixed_All
	{
		int? IsFixed_AllFn(
			string CurrCode,
			string Site = null);
	}
}

