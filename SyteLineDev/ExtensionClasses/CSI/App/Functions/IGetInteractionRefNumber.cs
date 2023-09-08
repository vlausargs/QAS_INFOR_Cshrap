//PROJECT NAME: Data
//CLASS NAME: IGetInteractionRefNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetInteractionRefNumber
	{
		string GetInteractionRefNumberFn(
			string RefType,
			Guid? RefRowPointer);
	}
}

