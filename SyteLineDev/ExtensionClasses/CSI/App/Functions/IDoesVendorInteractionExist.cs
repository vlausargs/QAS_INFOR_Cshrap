//PROJECT NAME: Data
//CLASS NAME: IDoesVendorInteractionExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDoesVendorInteractionExist
	{
		int? DoesVendorInteractionExistFn(
			string VendNum,
			Guid? RefRowPointer,
			string RefType,
			string Type);
	}
}

