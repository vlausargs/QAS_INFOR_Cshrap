//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroHasPostedTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroHasPostedTrans
	{
		int? SSSFSSroHasPostedTransFn(
			string SroNum,
			int? SroLine = null,
			int? SroOper = null);
	}
}

