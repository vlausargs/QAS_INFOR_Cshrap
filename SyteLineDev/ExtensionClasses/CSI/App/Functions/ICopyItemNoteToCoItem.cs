//PROJECT NAME: Data
//CLASS NAME: ICopyItemNoteToCoItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyItemNoteToCoItem
	{
		(int? ReturnCode,
			string Infobar) CopyItemNoteToCoItemSp(
			Guid? CoRowPointer,
			string Item,
			string Infobar);
	}
}

