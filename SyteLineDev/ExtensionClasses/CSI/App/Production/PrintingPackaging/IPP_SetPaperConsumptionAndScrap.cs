//PROJECT NAME: Production
//CLASS NAME: IPP_SetPaperConsumptionAndScrap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_SetPaperConsumptionAndScrap
	{
		(int? ReturnCode,
			string Infobar) PP_SetPaperConsumptionAndScrapSp(
			string Job,
			int? Suffix,
			int? OperNum,
			string Infobar);
	}
}

