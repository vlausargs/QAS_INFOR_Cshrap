//PROJECT NAME: Logistics
//CLASS NAME: IGenerateTmpPackListSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateTmpPackListSerial
	{
		(int? ReturnCode, string Infobar) GenerateTmpPackListSerialSp(Guid? ProcessId,
		string SerNum,
		int? PickGroup,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		int? Reserved,
		string Whse,
		string Loc,
		string Lot,
		string Infobar);
	}
}

