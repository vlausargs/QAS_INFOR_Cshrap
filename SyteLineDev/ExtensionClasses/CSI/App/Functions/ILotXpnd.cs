//PROJECT NAME: Data
//CLASS NAME: ILotXpnd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILotXpnd
	{
		(int? ReturnCode,
			string Infobar) LotXpndSp(
			string Infobar);
	}
}

