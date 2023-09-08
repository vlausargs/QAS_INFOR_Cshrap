//PROJECT NAME: Data
//CLASS NAME: ICoFBomPR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoFBomPR
	{
		(int? ReturnCode,
			decimal? TIncPrice,
			string Infobar) CoFBomPRSp(
			string PItem,
			string TFeatStr,
			string PCoNum,
			int? PCoLine,
			decimal? TIncPrice,
			string Infobar);
	}
}

