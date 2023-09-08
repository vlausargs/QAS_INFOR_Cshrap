//PROJECT NAME: Data
//CLASS NAME: IFTGetSLVersionSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTGetSLVersionSite
	{
		(int? ReturnCode,
			string Site,
			string SyteLineVersion,
			string Infobar) FTGetSLVersionSiteSp(
			string DefaultConfig,
			string Site,
			string SyteLineVersion,
			string Infobar);
	}
}

