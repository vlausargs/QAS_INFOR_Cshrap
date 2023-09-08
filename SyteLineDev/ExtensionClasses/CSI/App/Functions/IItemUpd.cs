//PROJECT NAME: Data
//CLASS NAME: IItemUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemUpd
	{
		(int? ReturnCode,
			string Item) ItemUpdSp(
			string Item,
			string DrawingNbr = null,
			string Revision = null);
	}
}

