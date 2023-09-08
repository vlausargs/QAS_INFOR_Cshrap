//PROJECT NAME: POS
//CLASS NAME: SSSPOSGetPartner.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public interface ISSSPOSGetPartner
	{
		(int? ReturnCode, byte? OValid, byte? OActive, string OName, string ODept, string OWhse, string ORefType, string ORefNum, int? ORefSeq, string OEmail, string OPassword, string OWorkCode, string Infobar) SSSPOSGetPartnerSp(string PartnerID = null,
		byte? OValid = null,
		byte? OActive = null,
		string OName = null,
		string ODept = null,
		string OWhse = null,
		string ORefType = null,
		string ORefNum = null,
		int? ORefSeq = null,
		string OEmail = null,
		string OPassword = null,
		string OWorkCode = null,
		string Infobar = null);
	}
	
	public class SSSPOSGetPartner : ISSSPOSGetPartner
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSGetPartner(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? OValid, byte? OActive, string OName, string ODept, string OWhse, string ORefType, string ORefNum, int? ORefSeq, string OEmail, string OPassword, string OWorkCode, string Infobar) SSSPOSGetPartnerSp(string PartnerID = null,
		byte? OValid = null,
		byte? OActive = null,
		string OName = null,
		string ODept = null,
		string OWhse = null,
		string ORefType = null,
		string ORefNum = null,
		int? ORefSeq = null,
		string OEmail = null,
		string OPassword = null,
		string OWorkCode = null,
		string Infobar = null)
		{
			FSPartnerType _PartnerID = PartnerID;
			ListYesNoType _OValid = OValid;
			ListYesNoType _OActive = OActive;
			NameType _OName = OName;
			DeptType _ODept = ODept;
			WhseType _OWhse = OWhse;
			FSRefTypeCEVType _ORefType = ORefType;
			FSRefNumType _ORefNum = ORefNum;
			FSRefLineType _ORefSeq = ORefSeq;
			EmailType _OEmail = OEmail;
			PasswordType _OPassword = OPassword;
			FSWorkCodeType _OWorkCode = OWorkCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSGetPartnerSp";
				
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OValid", _OValid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActive", _OActive, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OName", _OName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ODept", _ODept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OWhse", _OWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ORefType", _ORefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ORefNum", _ORefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ORefSeq", _ORefSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OEmail", _OEmail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OPassword", _OPassword, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OWorkCode", _OWorkCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OValid = _OValid;
				OActive = _OActive;
				OName = _OName;
				ODept = _ODept;
				OWhse = _OWhse;
				ORefType = _ORefType;
				ORefNum = _ORefNum;
				ORefSeq = _ORefSeq;
				OEmail = _OEmail;
				OPassword = _OPassword;
				OWorkCode = _OWorkCode;
				Infobar = _Infobar;
				
				return (Severity, OValid, OActive, OName, ODept, OWhse, ORefType, ORefNum, ORefSeq, OEmail, OPassword, OWorkCode, Infobar);
			}
		}
	}
}
