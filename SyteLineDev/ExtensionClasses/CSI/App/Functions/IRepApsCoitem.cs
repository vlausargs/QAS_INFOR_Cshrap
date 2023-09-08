//PROJECT NAME: Data
//CLASS NAME: IRepApsCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepApsCoitem
	{
		(int? ReturnCode,
			string Infobar) RepApsCoitemSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			DateTime? ProjectedDate,
			string Infobar);
	}
}

