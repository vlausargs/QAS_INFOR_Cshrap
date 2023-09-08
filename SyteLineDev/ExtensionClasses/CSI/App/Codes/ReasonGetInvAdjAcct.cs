//PROJECT NAME: Codes
//CLASS NAME: ReasonGetInvAdjAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface IReasonGetInvAdjAcct
	{
		(int? ReturnCode, string Acct, string AcctUnit1, string AcctUnit2, string AcctUnit3, string AcctUnit4, string AccessUnit1, string AccessUnit2, string AccessUnit3, string AccessUnit4, string Description, string Infobar, byte? AcctIsControl) ReasonGetInvAdjAcctSp(string ReasonCode,
		string ReasonClass,
		string Item,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Description,
		string Infobar,
		byte? ByContainer = (byte)0,
		byte? AcctIsControl = null);
	}
	
	public class ReasonGetInvAdjAcct : IReasonGetInvAdjAcct
	{
		readonly IApplicationDB appDB;
		
		public ReasonGetInvAdjAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Acct, string AcctUnit1, string AcctUnit2, string AcctUnit3, string AcctUnit4, string AccessUnit1, string AccessUnit2, string AccessUnit3, string AccessUnit4, string Description, string Infobar, byte? AcctIsControl) ReasonGetInvAdjAcctSp(string ReasonCode,
		string ReasonClass,
		string Item,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Description,
		string Infobar,
		byte? ByContainer = (byte)0,
		byte? AcctIsControl = null)
		{
			ReasonCodeType _ReasonCode = ReasonCode;
			ReasonClassType _ReasonClass = ReasonClass;
			ItemType _Item = Item;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			UnitCodeAccessType _AccessUnit1 = AccessUnit1;
			UnitCodeAccessType _AccessUnit2 = AccessUnit2;
			UnitCodeAccessType _AccessUnit3 = AccessUnit3;
			UnitCodeAccessType _AccessUnit4 = AccessUnit4;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			ListYesNoType _ByContainer = ByContainer;
			ListYesNoType _AcctIsControl = AcctIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReasonGetInvAdjAcctSp";
				
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonClass", _ReasonClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit1", _AccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit2", _AccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit3", _AccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit4", _AccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ByContainer", _ByContainer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctIsControl", _AcctIsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Acct = _Acct;
				AcctUnit1 = _AcctUnit1;
				AcctUnit2 = _AcctUnit2;
				AcctUnit3 = _AcctUnit3;
				AcctUnit4 = _AcctUnit4;
				AccessUnit1 = _AccessUnit1;
				AccessUnit2 = _AccessUnit2;
				AccessUnit3 = _AccessUnit3;
				AccessUnit4 = _AccessUnit4;
				Description = _Description;
				Infobar = _Infobar;
				AcctIsControl = _AcctIsControl;
				
				return (Severity, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, AccessUnit1, AccessUnit2, AccessUnit3, AccessUnit4, Description, Infobar, AcctIsControl);
			}
		}
	}
}
