//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSWarrExpireProcessLevel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSWarrExpireProcessLevel
	{
		(int? ReturnCode,
			string Infobar) SSSFSWarrExpireProcessLevelSp(
			string pcust_num,
			int? pcust_seq,
			string pcust_name,
			int? pCompID,
			string pitem,
			string pDescription,
			string pSerNum,
			string pWarrCode,
			DateTime? pExpireDate,
			string beg_childItem,
			string end_ChildItem,
			DateTime? beg_warr_expire,
			DateTime? end_warr_expire,
			int? ChildCompID,
			string Infobar);
	}
}

