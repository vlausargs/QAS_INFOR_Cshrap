//PROJECT NAME: Data
//CLASS NAME: IPoitemProjMatlXrefUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoitemProjMatlXrefUpdate
	{
		(int? ReturnCode,
			string Infobar) PoitemProjMatlXrefUpdateSp(
			string PoNum,
			int? PoLine,
			int? PoRelease,
			string Item,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Infobar);
	}
}

