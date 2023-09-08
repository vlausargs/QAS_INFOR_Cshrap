//PROJECT NAME: Production
//CLASS NAME: IPP_ProcessPrintingEstWB_CopyPrintData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_ProcessPrintingEstWB_CopyPrintData
	{
		(int? ReturnCode,
			string Infobar) PP_ProcessPrintingEstWB_CopyPrintDataSp(
			string QuoteType,
			string SourceJob,
			int? SourceSuffix,
			string TargetJob,
			int? TargetSuffix,
			string Infobar);
	}
}

