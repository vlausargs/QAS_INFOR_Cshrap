//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetCOCustInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSGetCOCustInfo
	{
		(int? ReturnCode,
		string oCustNum,
		int? oCustSeq) SSSFSGetCOCustInfoSp(
			string iCoNum,
			string oCustNum,
			int? oCustSeq);
	}
}

