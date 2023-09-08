//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROWipRel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROWipRel
	{
		(int? ReturnCode,
			string Infobar) SSSFSSROWipRelSp(
			string PSroNum,
			int? PSroLine,
			int? PSroOper,
			DateTime? PDate,
			DateTime? PBegTransDate,
			DateTime? PEndTransDate,
			int? PInclBillHold,
			int? PMarkBilled,
			string PJournalDesc,
			string Infobar,
			string InvNum = null,
			Guid? BufferJournal = null);
	}
}

