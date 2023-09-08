//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSCustContactInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSCustContactInfo
	{
		(int? ReturnCode,
			string Phone,
			string FaxNum,
			string Email,
			string Infobar) SSSFSCustContactInfoSp(
			string CustNum,
			int? CustSeq,
			string Name,
			string Phone,
			string FaxNum,
			string Email,
			string Infobar);
	}
}

