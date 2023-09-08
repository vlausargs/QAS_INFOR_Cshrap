//PROJECT NAME: DataCollection
//CLASS NAME: IDccycSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccycSerialSave
	{
		(int? ReturnCode, string Infobar) DccycSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		string Infobar);
	}
}

