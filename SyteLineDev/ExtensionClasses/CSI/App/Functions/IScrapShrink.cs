//PROJECT NAME: Data
//CLASS NAME: IScrapShrink.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IScrapShrink
	{
		decimal? ScrapShrinkFn(
			int? MrpParmShrinkFlag,
			string ApsParmApsMode,
			Guid? apsplanRowPointer);
	}
}

