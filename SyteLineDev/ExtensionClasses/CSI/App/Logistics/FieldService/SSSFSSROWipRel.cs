//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROWipRel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROWipRel : ISSSFSSROWipRel
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROWipRel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			Guid? BufferJournal = null)
		{
			FSSRONumType _PSroNum = PSroNum;
			FSSROLineType _PSroLine = PSroLine;
			FSSROOperType _PSroOper = PSroOper;
			CurrentDateType _PDate = PDate;
			DateType _PBegTransDate = PBegTransDate;
			DateType _PEndTransDate = PEndTransDate;
			FlagNyType _PInclBillHold = PInclBillHold;
			FlagNyType _PMarkBilled = PMarkBilled;
			LongListType _PJournalDesc = PJournalDesc;
			Infobar _Infobar = Infobar;
			InvNumType _InvNum = InvNum;
			RowPointerType _BufferJournal = BufferJournal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROWipRelSp";
				
				appDB.AddCommandParameter(cmd, "PSroNum", _PSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSroLine", _PSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSroOper", _PSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegTransDate", _PBegTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTransDate", _PEndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclBillHold", _PInclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMarkBilled", _PMarkBilled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJournalDesc", _PJournalDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BufferJournal", _BufferJournal, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
