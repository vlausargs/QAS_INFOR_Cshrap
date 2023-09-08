//PROJECT NAME: Production
//CLASS NAME: IFormulaTermValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IFormulaTermValidate
	{
		(int? ReturnCode, string Infobar) FormulaTermValidateSp(string PropertyName,
		string CollectionName,
		string OperationType = null,
		int? IncludeKeySequence = 0,
		string Infobar = null);
	}
}

