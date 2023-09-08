//PROJECT NAME: Finance
//CLASS NAME: IUpdateDimAndDimAttributes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IUpdateDimAndDimAttributes
	{
		int? UpdateDimAndDimAttributesSp(int? Selected,
		string ObjectName,
		string Attribute,
		string DimName,
		string DimDescription,
		int? Required);
	}
}

