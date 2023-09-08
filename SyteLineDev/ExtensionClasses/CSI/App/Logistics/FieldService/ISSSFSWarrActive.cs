//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSWarrActive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSWarrActive
	{
		(int? ReturnCode,
			int? OActive,
			string Infobar) SSSFSWarrActiveSp(
			int? ICompId,
			string IWarrCode,
			DateTime? IDate,
			int? IMeter,
			int? OActive,
			string Infobar);
	}
}

