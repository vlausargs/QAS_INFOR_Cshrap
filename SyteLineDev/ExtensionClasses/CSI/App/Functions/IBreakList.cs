//PROJECT NAME: Data
//CLASS NAME: IBreakList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBreakList
	{
		(int? ReturnCode,
			string Var1,
			string Var2,
			string Var3,
			string Var4,
			string Var5,
			string Var6,
			string Var7,
			string Var8,
			string Var9,
			string Var10,
			string Var11,
			string Var12,
			string Var13,
			string Var14,
			string Var15) BreakListSp(
			string List,
			string Delimeter = ",",
			string Var1 = null,
			string Var2 = null,
			string Var3 = null,
			string Var4 = null,
			string Var5 = null,
			string Var6 = null,
			string Var7 = null,
			string Var8 = null,
			string Var9 = null,
			string Var10 = null,
			string Var11 = null,
			string Var12 = null,
			string Var13 = null,
			string Var14 = null,
			string Var15 = null);
	}
}

