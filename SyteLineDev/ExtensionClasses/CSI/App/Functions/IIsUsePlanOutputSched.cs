//PROJECT NAME: Data
//CLASS NAME: IIsUsePlanOutputSched.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsUsePlanOutputSched
	{
		int? IsUsePlanOutputSchedFn(
			int? AltNo);
	}
}

