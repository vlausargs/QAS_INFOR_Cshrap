//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAddrSet2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAddrSet2
	{
		(int? ReturnCode,
			string Addr1_1,
			string Addr1_2,
			string Addr1_3,
			string Addr1_4,
			string Addr1_5,
			string Addr1_6,
			string Addr1_7,
			string Addr1_8,
			string Infobar) SSSFSAddrSet2Sp(
			string CustContact,
			string CustPhone,
			string CustName,
			string CustAddr1,
			string CustAddr2,
			string CustAddr3,
			string CustAddr4,
			string CustCity,
			string CustState,
			string CustZip,
			string CustCountry,
			string Addr1_1,
			string Addr1_2,
			string Addr1_3,
			string Addr1_4,
			string Addr1_5,
			string Addr1_6,
			string Addr1_7,
			string Addr1_8,
			string Infobar);
	}
}

