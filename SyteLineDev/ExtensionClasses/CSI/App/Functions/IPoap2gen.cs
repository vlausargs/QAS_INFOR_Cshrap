//PROJECT NAME: Data
//CLASS NAME: IPoap2gen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoap2gen
	{
		(int? ReturnCode,
			int? TDistSeq,
			string Infobar) Poap2genSp(
			int? PSign,
			Guid? AptrxRowPointer,
			string PVendCurrCode,
			int? PCurrPlaces,
			decimal? PFreight,
			decimal? PMiscCharges,
			decimal? PSalesTax,
			decimal? PSalesTax2,
			string PFormTitle,
			string CalledFrom,
			Guid? PProcessId,
			int? TDistSeq,
			string Infobar);
	}
}

