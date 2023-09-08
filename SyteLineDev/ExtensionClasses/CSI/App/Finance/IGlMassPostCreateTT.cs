//PROJECT NAME: Finance
//CLASS NAME: IGlMassPostCreateTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGlMassPostCreateTT
	{
		(int? ReturnCode, string Infobar) GlMassPostCreateTTSp(Guid? PSessionID,
		DateTime? PostThroughDate,
		string Infobar);
	}
}

