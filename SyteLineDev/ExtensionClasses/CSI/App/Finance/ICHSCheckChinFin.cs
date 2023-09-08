//PROJECT NAME: Finance
//CLASS NAME: ICHSCheckChinFin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICHSCheckChinFin
	{
		(int? ReturnCode, int? AvailChinFin) CHSCheckChinFinSp(int? AvailChinFin);
	}
}

