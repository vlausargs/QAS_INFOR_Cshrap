//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSyncReasons.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSyncReasons
	{
		int? SSSFSSyncReasonsSp(
			string iUpdateFrom,
			string iIncSroNum,
			Guid? iReasonRowPointer);
	}
}

