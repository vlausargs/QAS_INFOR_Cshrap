//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickListCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickListCoitem
	{
		(int? ReturnCode,
			Guid? PItemlocRowPointer,
			string Infobar) GenerateOrderPickListCoitemSp(
			Guid? PSessionID,
			int? PCoparmsPickwarnCo,
			string PPickwarn,
			int? PPostMatlIssues,
			int? PProcessBatchId,
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemItem,
			DateTime? PCoitemPickDate,
			decimal? PCoitemQtyOrdered,
			decimal? PCoitemQtyShipped,
			string PCoitemWhse,
			Guid? PCoitemRowPointer,
			int? PListByLoc,
			Guid? PItemlocRowPointer,
			string Infobar);
	}
}

