//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDispatchEvent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSDispatchEvent
	{
		(int? ReturnCode, string Infobar) SSSFSDispatchEventSp(string RefType,
		string IncNum,
		string Partner,
		DateTime? DispDate,
		string NoteContent,
		string Infobar);
	}
	
	public class SSSFSDispatchEvent : ISSSFSDispatchEvent
	{
		readonly IApplicationDB appDB;
		
		public SSSFSDispatchEvent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSDispatchEventSp(string RefType,
		string IncNum,
		string Partner,
		DateTime? DispDate,
		string NoteContent,
		string Infobar)
		{
			FSRefTypeJKNSType _RefType = RefType;
			FSIncNumType _IncNum = IncNum;
			FSPartnerType _Partner = Partner;
			DateTimeType _DispDate = DispDate;
			OleObjectType _NoteContent = NoteContent;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSDispatchEventSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncNum", _IncNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Partner", _Partner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispDate", _DispDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteContent", _NoteContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
