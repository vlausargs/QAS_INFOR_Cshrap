//PROJECT NAME: Data
//CLASS NAME: IPoitemProjMatlXrefCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoitemProjMatlXrefCreate
	{
		(int? ReturnCode,
			int? RefRelease,
			string Infobar) PoitemProjMatlXrefCreateSp(
			string PoNum,
			int? PoLine,
			int? PoRelease,
			string Item,
			string CostCode,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Infobar = null);
	}
}

