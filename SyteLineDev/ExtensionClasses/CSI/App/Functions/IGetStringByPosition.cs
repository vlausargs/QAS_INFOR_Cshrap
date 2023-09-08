//PROJECT NAME: Data
//CLASS NAME: IGetStringByPosition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetStringByPosition
	{
		string GetStringByPositionFn(
			string String,
			string Pos);
	}
}

