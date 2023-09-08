//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetCharacter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetCharacter
	{
		string SSSFSGetCharacterFn(
			int? CharValue);
	}
}

