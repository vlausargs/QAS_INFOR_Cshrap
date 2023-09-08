//PROJECT NAME: Logistics
//CLASS NAME: IGenerateDoSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateDoSeq
	{
		(int? ReturnCode, string ErrorMessage) GenerateDoSeqSp(string DoNum,
		int? DoLine,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		DateTime? CoShipDate,
		int? CoDateSeq,
		string ErrorMessage);
	}
}

