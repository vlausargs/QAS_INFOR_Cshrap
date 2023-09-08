//PROJECT NAME: Material
//CLASS NAME: IGetNextTrrcvLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetNextTrrcvLine
	{
		(int? ReturnCode, int? TrnLine,
		string Infobar) GetNextTrrcvLineSp(string TrnNum,
		int? TrnLine,
		string Infobar);
	}
}

