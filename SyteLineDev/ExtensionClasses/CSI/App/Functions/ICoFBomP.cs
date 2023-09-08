//PROJECT NAME: Data
//CLASS NAME: ICoFBomP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoFBomP
	{
		(int? ReturnCode,
			decimal? TIncPrice,
			string Infobar) CoFBomPSp(
			string PItem,
			string TFeatStr,
			string PCoNum,
			int? PCoLine,
			decimal? TIncPrice,
			string Infobar);
	}
}

