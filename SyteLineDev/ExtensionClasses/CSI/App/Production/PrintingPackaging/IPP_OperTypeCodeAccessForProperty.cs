//PROJECT NAME: Production
//CLASS NAME: IPP_OperTypeCodeAccessForProperty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_OperTypeCodeAccessForProperty
	{
		string PP_OperTypeCodeAccessForPropertyFn(
			string CollectionName,
			string PropertyName);
	}
}

