//PROJECT NAME: Logistics
//CLASS NAME: IGenerateGrnLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGenerateGrnLine
	{
		(int? ReturnCode, string Infobar) GenerateGrnLineSp(string VendNum,
		string GrnNum,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		DateTime? RcvdDate,
		int? DateSeq,
		int? FromPo,
		string Infobar);
	}
}

