//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedDispatchEmailDefInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedDispatchEmailDefInfo
	{
		(int? ReturnCode, string FromEmailAddr,
		string ToEmailAddr,
		string EmailSubject,
		string Infobar) SSSFSSchedDispatchEmailDefInfoSp(string PartnerId,
		string FromEmailAddr,
		string ToEmailAddr,
		string EmailSubject,
		string Infobar);
	}
	
	public class SSSFSSchedDispatchEmailDefInfo : ISSSFSSchedDispatchEmailDefInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedDispatchEmailDefInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string FromEmailAddr,
		string ToEmailAddr,
		string EmailSubject,
		string Infobar) SSSFSSchedDispatchEmailDefInfoSp(string PartnerId,
		string FromEmailAddr,
		string ToEmailAddr,
		string EmailSubject,
		string Infobar)
		{
			FSPartnerType _PartnerId = PartnerId;
			EmailType _FromEmailAddr = FromEmailAddr;
			EmailType _ToEmailAddr = ToEmailAddr;
			LongDescType _EmailSubject = EmailSubject;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedDispatchEmailDefInfoSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEmailAddr", _FromEmailAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToEmailAddr", _ToEmailAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmailSubject", _EmailSubject, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FromEmailAddr = _FromEmailAddr;
				ToEmailAddr = _ToEmailAddr;
				EmailSubject = _EmailSubject;
				Infobar = _Infobar;
				
				return (Severity, FromEmailAddr, ToEmailAddr, EmailSubject, Infobar);
			}
		}
	}
}
