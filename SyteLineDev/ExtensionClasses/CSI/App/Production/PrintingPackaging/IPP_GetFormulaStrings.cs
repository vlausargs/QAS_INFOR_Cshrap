//PROJECT NAME: Production
//CLASS NAME: IPP_GetFormulaStrings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_GetFormulaStrings
	{
		(int? ReturnCode, string PropertyString) PP_GetFormulaStringsSp(string CollectionName,
		string OperationType,
		string PropertyName,
		string PropertyString);
	}
}

