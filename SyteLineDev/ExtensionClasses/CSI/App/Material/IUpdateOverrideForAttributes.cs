//PROJECT NAME: Material
//CLASS NAME: IUpdateOverrideForAttributes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdateOverrideForAttributes
	{
		(int? ReturnCode, string Infobar) UpdateOverrideForAttributesSp(string ValColName,
		string Value,
		string Type,
		Guid? RowPointer,
		string Infobar);
	}
}

