//PROJECT NAME: Data
//CLASS NAME: IBldLstWhseJobmatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBldLstWhseJobmatl
	{
		int? BldLstWhseJobmatlSp(
			string Job,
			int? Suffix,
			int? StartOperNum,
			int? EndOperNum,
			string CurWhse,
			string ReprintPick);
	}
}

