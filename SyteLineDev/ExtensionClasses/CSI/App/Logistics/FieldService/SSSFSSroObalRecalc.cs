//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroObalRecalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroObalRecalc : ISSSFSSroObalRecalc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroObalRecalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSroObalRecalcSp(
			string SroNum,
			string Infobar,
			int? SetSro = 1,
			int? SetOpers = 1,
			int? SetTrans = 1,
			int? SroLine = null,
			int? SroOper = null,
			int? SetLines = 1)
		{
			FSSRONumType _SroNum = SroNum;
			InfobarType _Infobar = Infobar;
			ListYesNoType _SetSro = SetSro;
			ListYesNoType _SetOpers = SetOpers;
			ListYesNoType _SetTrans = SetTrans;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			ListYesNoType _SetLines = SetLines;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroObalRecalcSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SetSro", _SetSro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetOpers", _SetOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetTrans", _SetTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetLines", _SetLines, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
