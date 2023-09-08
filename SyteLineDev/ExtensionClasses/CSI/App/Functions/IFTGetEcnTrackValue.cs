//PROJECT NAME: Data
//CLASS NAME: IFTGetEcnTrackValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTGetEcnTrackValue
	{
		int? FTGetEcnTrackValueFn(
			string Item,
			string Job,
			int? Suffix,
			string JobType);
	}
}

