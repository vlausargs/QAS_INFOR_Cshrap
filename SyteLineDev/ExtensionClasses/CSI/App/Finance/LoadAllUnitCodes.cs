//PROJECT NAME: CSIFinance
//CLASS NAME: LoadAllUnitCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface ILoadAllUnitCodes
	{
		(int? ReturnCode, string Infobar) LoadAllUnitCodesSp(string StartAcct,
		string EndAcct,
		byte? CopyUnit1 = (byte)0,
		string StartUnitCode1 = null,
		string EndUnitCode1 = null,
		byte? CopyUnit2 = (byte)0,
		string StartUnitCode2 = null,
		string EndUnitCode2 = null,
		byte? CopyUnit3 = (byte)0,
		string StartUnitCode3 = null,
		string EndUnitCode3 = null,
		byte? CopyUnit4 = (byte)0,
		string StartUnitCode4 = null,
		string EndUnitCode4 = null,
		string Infobar = null);
	}
	
	public class LoadAllUnitCodes : ILoadAllUnitCodes
	{
		readonly IApplicationDB appDB;
		
		public LoadAllUnitCodes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadAllUnitCodesSp(string StartAcct,
		string EndAcct,
		byte? CopyUnit1 = (byte)0,
		string StartUnitCode1 = null,
		string EndUnitCode1 = null,
		byte? CopyUnit2 = (byte)0,
		string StartUnitCode2 = null,
		string EndUnitCode2 = null,
		byte? CopyUnit3 = (byte)0,
		string StartUnitCode3 = null,
		string EndUnitCode3 = null,
		byte? CopyUnit4 = (byte)0,
		string StartUnitCode4 = null,
		string EndUnitCode4 = null,
		string Infobar = null)
		{
			AcctType _StartAcct = StartAcct;
			AcctType _EndAcct = EndAcct;
			ListYesNoType _CopyUnit1 = CopyUnit1;
			UnitCode1Type _StartUnitCode1 = StartUnitCode1;
			UnitCode1Type _EndUnitCode1 = EndUnitCode1;
			ListYesNoType _CopyUnit2 = CopyUnit2;
			UnitCode2Type _StartUnitCode2 = StartUnitCode2;
			UnitCode2Type _EndUnitCode2 = EndUnitCode2;
			ListYesNoType _CopyUnit3 = CopyUnit3;
			UnitCode3Type _StartUnitCode3 = StartUnitCode3;
			UnitCode3Type _EndUnitCode3 = EndUnitCode3;
			ListYesNoType _CopyUnit4 = CopyUnit4;
			UnitCode4Type _StartUnitCode4 = StartUnitCode4;
			UnitCode4Type _EndUnitCode4 = EndUnitCode4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadAllUnitCodesSp";
				
				appDB.AddCommandParameter(cmd, "StartAcct", _StartAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndAcct", _EndAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUnit1", _CopyUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartUnitCode1", _StartUnitCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnitCode1", _EndUnitCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUnit2", _CopyUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartUnitCode2", _StartUnitCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnitCode2", _EndUnitCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUnit3", _CopyUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartUnitCode3", _StartUnitCode3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnitCode3", _EndUnitCode3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUnit4", _CopyUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartUnitCode4", _StartUnitCode4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnitCode4", _EndUnitCode4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
