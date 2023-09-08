//PROJECT NAME: Production
//CLASS NAME: IPP_PostSavePrintingEstWorkbenchOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPP_PostSavePrintingEstWorkbenchOper
	{
		(int? ReturnCode, string Infobar) PP_PostSavePrintingEstWorkbenchOperSp(string Job,
		int? Suffix,
		int? OperNum,
		string WC,
		string Infobar);
	}
}

