//PROJECT NAME: Production
//CLASS NAME: IPP_ProcessPrintingEstWB_CalcPrintPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_ProcessPrintingEstWB_CalcPrintPrice
	{
		(int? ReturnCode,
			string Infobar) PP_ProcessPrintingEstWB_CalcPrintPriceSp(
			string RootJob,
			int? RootSuffix,
			string Infobar);
	}
}

