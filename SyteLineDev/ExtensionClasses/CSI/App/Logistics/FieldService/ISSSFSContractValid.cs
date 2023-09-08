//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContractValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContractValid
	{
		int? SSSFSContractValidFn(
			string Contract,
			int? ContLine,
			DateTime? TestDate);
	}
}

