//PROJECT NAME: Material
//CLASS NAME: IInsertOverrideForAttributes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IInsertOverrideForAttributes
	{
		(int? ReturnCode, Guid? RowPointer,
		string Infobar) InsertOverrideForAttributesSp(string ValColName,
		string Value,
		string Type,
		Guid? RefRowPointer,
		Guid? RowPointer,
		string Infobar);
	}
}

