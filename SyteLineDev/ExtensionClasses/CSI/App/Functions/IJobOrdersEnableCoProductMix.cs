//PROJECT NAME: Data
//CLASS NAME: IJobOrdersEnableCoProductMix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobOrdersEnableCoProductMix
	{
		int? JobOrdersEnableCoProductMixFn(
			string Stat,
			string Job,
			int? Suffix,
			string RootJob,
			int? RootSuffix,
			string RefJob,
			int? RefSuffix);
	}
}

