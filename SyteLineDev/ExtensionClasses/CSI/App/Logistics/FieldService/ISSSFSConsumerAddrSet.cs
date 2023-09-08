//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConsumerAddrSet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConsumerAddrSet
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
			string Infobar) SSSFSConsumerAddrSetSp(
			int? ContactNum,
			string UsrNum,
			int? UsrSeq,
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

