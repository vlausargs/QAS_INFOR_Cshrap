//PROJECT NAME: Finance
//CLASS NAME: IFRFecValidateParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFRFecValidateParms
	{
		(int? ReturnCode, int? PPrintFinal,
		DateTime? PEndDate,
		int? PPeriod,
		int? PPromptFlag,
		string Infobar) FRFecValidateParmsSp(int? PYear,
		int? PPrintFinal,
		DateTime? PEndDate,
		int? PPeriod,
		int? PPromptFlag,
		string Infobar);
	}
}

