//PROJECT NAME: Data
//CLASS NAME: IPrtrxgd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrtrxgd
	{
		(int? ReturnCode,
			string Infobar) PrtrxgdSp(
			string SEmployee,
			string EEmployee,
			string PEmplType,
			string PPrDelWhich,
			string Infobar,
			string PStartEmpCate = null,
			string PEndEmpCate = null);
	}
}

