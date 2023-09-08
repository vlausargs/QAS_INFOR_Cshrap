//PROJECT NAME: Data
//CLASS NAME: IValidatePriority.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidatePriority
	{
		int? ValidatePrioritySp(
			string PApsSite,
			int? PNewPriority,
			int? POldPriority);
	}
}

