//PROJECT NAME: THLOC
//CLASS NAME: ITHAGetCompNameAndAddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.THLOC
{
	public interface ITHAGetCompNameAndAddr
	{
		(int? ReturnCode, string CompName,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string TaxRegNum,
		string Infobar,
        string BranchId) THAGetCompNameAndAddrSp(string CompName,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string TaxRegNum,
		string Infobar,
        string BranchId);
	}
}

