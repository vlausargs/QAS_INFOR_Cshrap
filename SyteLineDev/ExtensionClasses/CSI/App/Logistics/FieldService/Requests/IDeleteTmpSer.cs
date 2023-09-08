//PROJECT NAME: Logistics
//CLASS NAME: IDeleteTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface IDeleteTmpSer
	{
		int? DeleteTmpSerSp(Guid? TmpSerId);
	}
}

