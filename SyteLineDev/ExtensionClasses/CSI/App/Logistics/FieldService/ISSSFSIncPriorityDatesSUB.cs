//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSIncPriorityDatesSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSIncPriorityDatesSub
	{
		(int? ReturnCode,
			DateTime? CalcDateTime,
			string Infobar) SSSFSIncPriorityDatesSubSp(
			DateTime? IncDateTime,
			int? ParmDays,
			decimal? ParmHrs,
			string DateBasis,
			string CustNum,
			string SerNum,
			string Item,
			DateTime? CalcDateTime,
			string Infobar);
	}
}

