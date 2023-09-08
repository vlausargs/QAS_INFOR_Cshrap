//PROJECT NAME: Data
//CLASS NAME: IBldPcst.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBldPcst
	{
		int? BldPcstSp(
			string CostNum,
			string RefType,
			string RefNum,
			int? RefLine,
			int? DeleteOld,
			string CostCodeType);
	}
}

