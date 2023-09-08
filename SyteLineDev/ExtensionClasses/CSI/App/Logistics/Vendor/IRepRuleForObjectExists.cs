//PROJECT NAME: Logistics
//CLASS NAME: IRepRuleForObjectExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IRepRuleForObjectExists
	{
		(int? ReturnCode, int? RepRuleForObjectExists) RepRuleForObjectExistsSp(string SourceSite,
		string RepCategory,
		string RepCatObject,
		int? RepCatObjectType,
		int? RepRuleForObjectExists);

		int? RepRuleForObjectExistsFn(
			string SourceSite,
			string RepCategory,
			string RepCatObject,
			int? RepCatObjectType);
	}
}

