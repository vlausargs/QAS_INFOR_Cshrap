//PROJECT NAME: Material
//CLASS NAME: IMrpParmChkLowSet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpParmChkLowSet
	{
		int? MrpParmChkLowSetSp(int? ChkLow);
	}
}

