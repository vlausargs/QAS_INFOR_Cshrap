//PROJECT NAME: Finance
//CLASS NAME: CalcBalBulk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class CalcBalBulk : ICalcBalBulk
	{
		readonly IApplicationDB appDB;
		
		public CalcBalBulk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CalcBalBulkSp(
			DateTime? DateStarting,
			DateTime? DateEnding,
			string StartingAccount,
			string EndingAccount,
			int? IgnoreUnit1,
			int? IgnoreUnit2,
			int? IgnoreUnit3,
			int? IgnoreUnit4,
			string UnitCode1Starting,
			string UnitCode1Ending,
			string UnitCode2Starting,
			string UnitCode2Ending,
			string UnitCode3Starting,
			string UnitCode3Ending,
			string UnitCode4Starting,
			string UnitCode4Ending,
			string ChartTypes,
			int? SeparateDrCrAmounts,
			string UseSite,
			int? SetNumber = 0,
			string Infobar = null)
		{
			DateType _DateStarting = DateStarting;
			DateType _DateEnding = DateEnding;
			AcctType _StartingAccount = StartingAccount;
			AcctType _EndingAccount = EndingAccount;
			ListYesNoType _IgnoreUnit1 = IgnoreUnit1;
			ListYesNoType _IgnoreUnit2 = IgnoreUnit2;
			ListYesNoType _IgnoreUnit3 = IgnoreUnit3;
			ListYesNoType _IgnoreUnit4 = IgnoreUnit4;
			UnitCode1Type _UnitCode1Starting = UnitCode1Starting;
			UnitCode1Type _UnitCode1Ending = UnitCode1Ending;
			UnitCode2Type _UnitCode2Starting = UnitCode2Starting;
			UnitCode2Type _UnitCode2Ending = UnitCode2Ending;
			UnitCode3Type _UnitCode3Starting = UnitCode3Starting;
			UnitCode3Type _UnitCode3Ending = UnitCode3Ending;
			UnitCode4Type _UnitCode4Starting = UnitCode4Starting;
			UnitCode4Type _UnitCode4Ending = UnitCode4Ending;
			InfobarType _ChartTypes = ChartTypes;
			ByteType _SeparateDrCrAmounts = SeparateDrCrAmounts;
			SiteType _UseSite = UseSite;
			IntType _SetNumber = SetNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcBalBulkSp";
				
				appDB.AddCommandParameter(cmd, "DateStarting", _DateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEnding", _DateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingAccount", _StartingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAccount", _EndingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreUnit1", _IgnoreUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreUnit2", _IgnoreUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreUnit3", _IgnoreUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreUnit4", _IgnoreUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode1Starting", _UnitCode1Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode1Ending", _UnitCode1Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode2Starting", _UnitCode2Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode2Ending", _UnitCode2Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode3Starting", _UnitCode3Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode3Ending", _UnitCode3Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode4Starting", _UnitCode4Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode4Ending", _UnitCode4Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartTypes", _ChartTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SeparateDrCrAmounts", _SeparateDrCrAmounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseSite", _UseSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetNumber", _SetNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
