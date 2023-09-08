//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSWSSchedSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSWSSchedSave
	{
		int SSSFSWSSchedSaveSp(Guid? RowPointer,
		                       Guid? ParentRowPointer,
		                       string PartnerId,
		                       DateTime? SchedDate,
		                       decimal? Hrs,
		                       int? NewDaySeq,
		                       int? NewTaskSeq,
		                       ref string Infobar);
	}
	
	public class SSSFSWSSchedSave : ISSSFSWSSchedSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSWSSchedSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSWSSchedSaveSp(Guid? RowPointer,
		                              Guid? ParentRowPointer,
		                              string PartnerId,
		                              DateTime? SchedDate,
		                              decimal? Hrs,
		                              int? NewDaySeq,
		                              int? NewTaskSeq,
		                              ref string Infobar)
		{
			RowPointerType _RowPointer = RowPointer;
			RowPointerType _ParentRowPointer = ParentRowPointer;
			FSPartnerType _PartnerId = PartnerId;
			DateTimeType _SchedDate = SchedDate;
			HoursOffType _Hrs = Hrs;
			FSSeqType _NewDaySeq = NewDaySeq;
			FSSeqType _NewTaskSeq = NewTaskSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSWSSchedSaveSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentRowPointer", _ParentRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedDate", _SchedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Hrs", _Hrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewDaySeq", _NewDaySeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewTaskSeq", _NewTaskSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
