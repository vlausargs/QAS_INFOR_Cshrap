//PROJECT NAME: Data
//CLASS NAME: ICreateSubjob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateSubjob
	{
		(int? ReturnCode,
			int? ToSequence,
			string Infobar) CreateSubjobSp(
			Guid? ItemRowPointer,
			string ItemJob,
			string ToJob,
			int? ToSuffix,
			int? ToOperNum,
			int? ToSequence,
			string ToJobmatlUnits,
			string JobmatlItem,
			string JobmatlRefType,
			decimal? ToJobmatlMatlQty,
			decimal? FromQtyReleased,
			string Infobar,
			string CoitemFeatStr = null,
			decimal? HrsPerDay = 0,
			int? CalcSubJobDates = 0,
			string ToType = null,
			int? CopyUetValues = 0);
	}
}

