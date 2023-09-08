//PROJECT NAME: Data
//CLASS NAME: CoXcpyJ.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoXcpyJ : ICoXcpyJ
	{
		readonly IApplicationDB appDB;
		
		public CoXcpyJ(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			decimal? ReturnIncPrice) CoXcpyJSp(
			string FeatStr,
			string Item,
			string ItemJob,
			string CurJob,
			int? CurSuffix,
			int? ExplodePhantom = 0,
			int? CalledFromItemCreate = 0,
			string CoNum = null,
			int? CoLine = null,
			string ToType = null,
			string Infobar = null,
			decimal? HrsPerDay = 0,
			int? CalcSubJobDates = 0,
			int? CopyUetValues = 0,
			int? CalcIncPrice = 0,
			decimal? ReturnIncPrice = 0)
		{
			FeatStrType _FeatStr = FeatStr;
			ItemType _Item = Item;
			JobType _ItemJob = ItemJob;
			JobType _CurJob = CurJob;
			SuffixType _CurSuffix = CurSuffix;
			ListYesNoType _ExplodePhantom = ExplodePhantom;
			ListYesNoType _CalledFromItemCreate = CalledFromItemCreate;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			StringType _ToType = ToType;
			InfobarType _Infobar = Infobar;
			GenericDecimalType _HrsPerDay = HrsPerDay;
			ListYesNoType _CalcSubJobDates = CalcSubJobDates;
			ListYesNoType _CopyUetValues = CopyUetValues;
			ListYesNoType _CalcIncPrice = CalcIncPrice;
			CostPrcType _ReturnIncPrice = ReturnIncPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoXcpyJSp";
				
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemJob", _ItemJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurJob", _CurJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurSuffix", _CurSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExplodePhantom", _ExplodePhantom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromItemCreate", _CalledFromItemCreate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToType", _ToType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HrsPerDay", _HrsPerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcSubJobDates", _CalcSubJobDates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcIncPrice", _CalcIncPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnIncPrice", _ReturnIncPrice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				ReturnIncPrice = _ReturnIncPrice;
				
				return (Severity, Infobar, ReturnIncPrice);
			}
		}
	}
}
