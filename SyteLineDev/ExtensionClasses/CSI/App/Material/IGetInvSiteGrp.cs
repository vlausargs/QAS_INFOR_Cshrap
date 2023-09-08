//PROJECT NAME: Material
//CLASS NAME: IGetInvSiteGrp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetInvSiteGrp
	{
		(int? ReturnCode, string InvSiteGrp) GetInvSiteGrpSp(decimal? Userid,
		string InvSiteGrp);
	}
}

