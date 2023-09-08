//PROJECT NAME: Data
//CLASS NAME: IFastJobmatlCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFastJobmatlCopy
	{
		(int? ReturnCode,
			string Infobar) FastJobmatlCopySp(
			Guid? SessionID,
			decimal? MatlQty,
			string Units,
			decimal? ScrapFact,
			string JobItem,
			DateTime? EffectDate,
			string ToJob,
			int? ToSuffix,
			string Infobar,
			int? ResequenceOperations = 0,
			int? OperNumOffset = 0,
			string FromJob = null,
			int? FromSuffix = 0);
	}
}

