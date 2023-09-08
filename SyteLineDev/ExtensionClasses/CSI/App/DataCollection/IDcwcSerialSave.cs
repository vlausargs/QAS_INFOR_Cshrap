//PROJECT NAME: DataCollection
//CLASS NAME: IDcwcSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcwcSerialSave
	{
		(int? ReturnCode, string Infobar) DcwcSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		string Infobar);
	}
}

