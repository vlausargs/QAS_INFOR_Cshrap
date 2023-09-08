//PROJECT NAME: Data
//CLASS NAME: IApp_GetListNonMultiSiteTabsCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_GetListNonMultiSiteTabsCopy
	{
		(int? ReturnCode,
			string Infobar) App_GetListNonMultiSiteTabsCopySp(
			string SourceServer,
			string SourceDB,
			string Infobar);
	}
}

