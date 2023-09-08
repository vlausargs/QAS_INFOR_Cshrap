//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPartReimbProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPartReimbProcess
	{
		(int? ReturnCode, string InfoBar) SSSFSPartReimbProcessSp(string PPartnerId,
		decimal? PMiscCharges,
		decimal? PAmtDue,
		Guid? SessionID,
		string PVendNum,
		string PInvNum,
		DateTime? PInvDate,
		DateTime? PDistDate,
		string PBatchId,
		string NoteContent,
		int? PreRegister,
		string InfoBar);
	}
	
	public class SSSFSPartReimbProcess : ISSSFSPartReimbProcess
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPartReimbProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) SSSFSPartReimbProcessSp(string PPartnerId,
		decimal? PMiscCharges,
		decimal? PAmtDue,
		Guid? SessionID,
		string PVendNum,
		string PInvNum,
		DateTime? PInvDate,
		DateTime? PDistDate,
		string PBatchId,
		string NoteContent,
		int? PreRegister,
		string InfoBar)
		{
			FSPartnerType _PPartnerId = PPartnerId;
			GenericDecimalType _PMiscCharges = PMiscCharges;
			GenericDecimalType _PAmtDue = PAmtDue;
			RowPointerType _SessionID = SessionID;
			VendNumType _PVendNum = PVendNum;
			VendInvNumType _PInvNum = PInvNum;
			DateType _PInvDate = PInvDate;
			DateType _PDistDate = PDistDate;
			FSReimbBatchIdType _PBatchId = PBatchId;
			StringType _NoteContent = NoteContent;
			PreRegisterType _PreRegister = PreRegister;
			Infobar _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPartReimbProcessSp";
				
				appDB.AddCommandParameter(cmd, "PPartnerId", _PPartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmtDue", _PAmtDue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDate", _PDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBatchId", _PBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteContent", _NoteContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreRegister", _PreRegister, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
