//PROJECT NAME: Production
//CLASS NAME: IPP_CLM_OperationTypeFormulas.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_CLM_OperationTypeFormulas
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PP_CLM_OperationTypeFormulasSp(string CollectionName,
		string OperationType = null,
		int? IncludeKeySequence = 0);
	}
}

