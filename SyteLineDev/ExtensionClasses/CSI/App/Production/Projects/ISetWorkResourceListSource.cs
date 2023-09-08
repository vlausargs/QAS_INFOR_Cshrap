//PROJECT NAME: Production
//CLASS NAME: ISetWorkResourceListSource.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ISetWorkResourceListSource
	{
		(int? ReturnCode, string Ref_num_ido_source,
		string Ref_name_property_source,
		string Ref_num_property_source,
		string ref_num_ido_source_filter,
		string Infobar) SetWorkResourceListSourceSp(string ResourceType,
		string Ref_num_ido_source,
		string Ref_name_property_source,
		string Ref_num_property_source,
		string ref_num_ido_source_filter,
		string Infobar);
	}
}

