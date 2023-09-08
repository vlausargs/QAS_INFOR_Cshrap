//PROJECT NAME: Data
//CLASS NAME: IGetEcnTrackValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEcnTrackValue
	{
		int? GetEcnTrackValueFn(
			string Item,
			string Job,
			int? Suffix,
			string JobType);
	}
}

