//PROJECT NAME: Production
//CLASS NAME: IPP_ParsedFormulaProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_ParsedFormulaProcess
	{
		(int? ReturnCode,
			string Formula,
			string BigDSql,
			int? NeedParsed) PP_ParsedFormulaProcessSp(
			string OperType,
			string Job = null,
			int? UpdateFormula = 0,
			string Formula = null,
			string BigDSql = null,
			int? NeedParsed = null);
	}
}

