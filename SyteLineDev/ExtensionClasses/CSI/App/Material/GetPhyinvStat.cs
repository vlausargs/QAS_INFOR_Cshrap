//PROJECT NAME: CSIMaterial
//CLASS NAME: GetPhyinvStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetPhyinvStat
	{
		int GetPhyinvStatSp(string Whse,
		                    ref byte? PhyInvFlg,
		                    ref string CountMeth,
		                    ref string ValChecker,
		                    ref string ValCounter,
		                    ref int? LastSheet,
		                    ref int? LastTag,
		                    ref short? Increment);
	}
	
	public class GetPhyinvStat : IGetPhyinvStat
	{
		readonly IApplicationDB appDB;
		
		public GetPhyinvStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetPhyinvStatSp(string Whse,
		                           ref byte? PhyInvFlg,
		                           ref string CountMeth,
		                           ref string ValChecker,
		                           ref string ValCounter,
		                           ref int? LastSheet,
		                           ref int? LastTag,
		                           ref short? Increment)
		{
			WhseType _Whse = Whse;
			ListYesNoType _PhyInvFlg = PhyInvFlg;
			PhytagsCountMethType _CountMeth = CountMeth;
			PhyInvValCounterType _ValChecker = ValChecker;
			PhyInvValCounterType _ValCounter = ValCounter;
			SheetTagNumType _LastSheet = LastSheet;
			SheetTagNumType _LastTag = LastTag;
			SheetTagIncrementType _Increment = Increment;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPhyinvStatSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhyInvFlg", _PhyInvFlg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CountMeth", _CountMeth, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValChecker", _ValChecker, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValCounter", _ValCounter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastSheet", _LastSheet, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastTag", _LastTag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Increment", _Increment, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PhyInvFlg = _PhyInvFlg;
				CountMeth = _CountMeth;
				ValChecker = _ValChecker;
				ValCounter = _ValCounter;
				LastSheet = _LastSheet;
				LastTag = _LastTag;
				Increment = _Increment;
				
				return Severity;
			}
		}
	}
}
