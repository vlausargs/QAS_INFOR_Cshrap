//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroHasUnpostedTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroHasUnpostedTrans
	{
		int? SSSFSSroHasUnpostedTransFn(
			string SroNum,
			int? SroLine = null,
			int? SroOper = null);
	}
}

