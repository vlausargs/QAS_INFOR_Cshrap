//PROJECT NAME: Data
//CLASS NAME: IInter11.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInter11
	{
		(int? ReturnCode,
			int? TcSeqReturn) Inter11Sp(
			int? TLevel,
			string TItem,
			string TGroupItem,
			decimal? TQty,
			string TUm,
			string TUnit,
			string TRef,
			string TType,
			DateTime? TEffectiveDate,
			Guid? TRecid,
			int? DisplayRefer,
			int? TcSeq,
			int? TcSeqReturn,
			int? PrintAlternateMaterials = null,
			int? IncludeRevision = 0,
			string TcItemJob = null,
			int? AltGroup = null,
			int? AltGroupRank = null);
	}
}

