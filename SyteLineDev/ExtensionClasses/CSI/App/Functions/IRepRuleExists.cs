//PROJECT NAME: Data
//CLASS NAME: IRepRuleExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepRuleExists
	{
		int? RepRuleExistsFn(
			string SourceSite,
			string RepCatObject,
			int? RepCatObjectType);
	}
}

