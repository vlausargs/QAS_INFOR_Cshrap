//PROJECT NAME: Data
//CLASS NAME: IGetItemLang.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemLang
	{
		(int? ReturnCode,
			string Description,
			string Overview,
			Guid? RowPointer,
			string Infobar) GetItemLangSp(
			string PItem,
			string PLangCode,
			string Description,
			string Overview,
			Guid? RowPointer,
			string Infobar);
	}
}

