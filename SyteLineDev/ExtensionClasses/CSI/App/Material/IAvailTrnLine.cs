//PROJECT NAME: Material
//CLASS NAME: IAvailTrnLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IAvailTrnLine
	{
		(int? ReturnCode, int? TrnLine,
		string Infobar) AvailTrnLineSp(string TrnNum,
		int? TrnLine,
		string Infobar);
	}
}

