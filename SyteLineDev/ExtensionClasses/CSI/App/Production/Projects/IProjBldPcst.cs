//PROJECT NAME: Production
//CLASS NAME: IProjBldPcst.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjBldPcst
	{
		int? ProjBldPcstSp(
			string RefNum,
			string ProjType,
			string ProjNum,
			int? TaskNum,
			int? DeleteOld);
	}
}

