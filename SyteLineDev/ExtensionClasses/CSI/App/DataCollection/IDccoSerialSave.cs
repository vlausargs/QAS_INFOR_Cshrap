//PROJECT NAME: DataCollection
//CLASS NAME: IDccoSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccoSerialSave
	{
		(int? ReturnCode, string Infobar) DccoSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		string Infobar);
	}
}

