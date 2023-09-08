//PROJECT NAME: Material
//CLASS NAME: IGetNextTrnShipLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetNextTrnShipLine
	{
		(int? ReturnCode, int? TrnLine,
		string Infobar) GetNextTrnShipLineSp(string TrnNum,
		int? TrnLine,
		string Infobar);
	}
}

