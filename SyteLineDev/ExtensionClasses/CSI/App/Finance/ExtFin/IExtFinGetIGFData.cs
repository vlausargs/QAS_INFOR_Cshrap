//PROJECT NAME: Finance
//CLASS NAME: IExtFinGetIGFData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinGetIGFData
	{
		(int? ReturnCode,
			string Infobar) ExtFinGetIGFDataSp(
			string Request,
			string StartingCustNum,
			string EndingCustNum,
			string Infobar);
	}
}

