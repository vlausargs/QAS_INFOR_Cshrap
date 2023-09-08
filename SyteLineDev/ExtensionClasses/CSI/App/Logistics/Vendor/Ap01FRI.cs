//PROJECT NAME: Logistics
//CLASS NAME: Ap01FRI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAp01FRI
	{
		(int? ReturnCode, string Infobar) Ap01FRISp(Guid? PSessionID,
		decimal? PUserID,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		string PSortNameNum = "Number",
		string PPayType = null,
		byte? PDistDetail = null,
		int? PCurrCheckNum = null,
		string PCurBankCode = null,
		string PPayTypeCodeSt = null,
		string Infobar = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null,
		string PFormType = null);
	}
	
	public class Ap01FRI : IAp01FRI
	{
		readonly IApplicationDB appDB;
		
		public Ap01FRI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) Ap01FRISp(Guid? PSessionID,
		decimal? PUserID,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		string PSortNameNum = "Number",
		string PPayType = null,
		byte? PDistDetail = null,
		int? PCurrCheckNum = null,
		string PCurBankCode = null,
		string PPayTypeCodeSt = null,
		string Infobar = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null,
		string PFormType = null)
		{
			RowPointerType _PSessionID = PSessionID;
			TokenType _PUserID = PUserID;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			LongDescType _PSortNameNum = PSortNameNum;
			NameType _PPayType = PPayType;
			ListYesNoType _PDistDetail = PDistDetail;
			ApCheckNumType _PCurrCheckNum = PCurrCheckNum;
			BankCodeType _PCurBankCode = PCurBankCode;
			AppmtPayTypeType _PPayTypeCodeSt = PPayTypeCodeSt;
			InfobarType _Infobar = Infobar;
			DateType _PPayDateStarting = PPayDateStarting;
			DateType _PPayDateEnding = PPayDateEnding;
			NameType _PFormType = PFormType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Ap01FRISp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserID", _PUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortNameNum", _PSortNameNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDetail", _PDistDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCheckNum", _PCurrCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurBankCode", _PCurBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayTypeCodeSt", _PPayTypeCodeSt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFormType", _PFormType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
