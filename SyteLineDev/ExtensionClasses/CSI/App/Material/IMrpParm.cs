//PROJECT NAME: Material
//CLASS NAME: IMrpParm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpParm
	{
		(int? ReturnCode,
			int? TFcstAhd,
			int? TFcstBhd,
			int? TExcAhd,
			int? TExcBhd,
			int? TExcAhdJ,
			int? TExcBhdJ,
			string Infobar) MrpParmSp(
			string PrevProd,
			int? TFcstAhd,
			int? TFcstBhd,
			int? TExcAhd,
			int? TExcBhd,
			int? TExcAhdJ,
			int? TExcBhdJ,
			string Infobar);
	}
}

