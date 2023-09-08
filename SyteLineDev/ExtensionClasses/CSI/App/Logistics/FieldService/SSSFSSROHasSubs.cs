//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROHasSubs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROHasSubs : ISSSFSSROHasSubs
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROHasSubs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? SROLine,
			int? SROOper,
			int? HasMatl,
			int? HasLabor,
			int? HasMisc,
			int? HasLineMatl,
			int? HasInv,
			int? HasDeposit,
			string Infobar) SSSFSSROHasSubsSp(
			string SRONum,
			int? SROLine,
			int? SROOper,
			int? HasMatl,
			int? HasLabor,
			int? HasMisc,
			int? HasLineMatl,
			int? HasInv,
			int? HasDeposit,
			string Infobar)
		{
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			ListYesNoType _HasMatl = HasMatl;
			ListYesNoType _HasLabor = HasLabor;
			ListYesNoType _HasMisc = HasMisc;
			ListYesNoType _HasLineMatl = HasLineMatl;
			ListYesNoType _HasInv = HasInv;
			ListYesNoType _HasDeposit = HasDeposit;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROHasSubsSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HasMatl", _HasMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HasLabor", _HasLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HasMisc", _HasMisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HasLineMatl", _HasLineMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HasInv", _HasInv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HasDeposit", _HasDeposit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SROLine = _SROLine;
				SROOper = _SROOper;
				HasMatl = _HasMatl;
				HasLabor = _HasLabor;
				HasMisc = _HasMisc;
				HasLineMatl = _HasLineMatl;
				HasInv = _HasInv;
				HasDeposit = _HasDeposit;
				Infobar = _Infobar;
				
				return (Severity, SROLine, SROOper, HasMatl, HasLabor, HasMisc, HasLineMatl, HasInv, HasDeposit, Infobar);
			}
		}
	}
}
