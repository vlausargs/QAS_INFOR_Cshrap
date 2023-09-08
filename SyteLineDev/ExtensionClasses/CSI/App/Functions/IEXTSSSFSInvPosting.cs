//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSInvPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSInvPosting
	{
		(int? ReturnCode,
			Guid? CoRowPointer,
			string CoCustNum,
			int? CoCustSeq,
			string Infobar,
			int? InclSROInOnOrdBal) EXTSSSFSInvPostingSp(
			string ArinvInvNum,
			Guid? CoRowPointer,
			string CoCustNum,
			int? CoCustSeq,
			string Infobar,
			int? InclSROInOnOrdBal = 1);
	}
}

