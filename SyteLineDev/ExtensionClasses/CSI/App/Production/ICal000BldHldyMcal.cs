//PROJECT NAME: Production
//CLASS NAME: ICal000BldHldyMcal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICal000BldHldyMcal
	{
		(int? ReturnCode, string Infobar) Cal000BldHldyMcalSp(int? PTSfcFlag,
		DateTime? PTMdayDate,
		int? AltNo,
		string Infobar);
	}
}

