//PROJECT NAME: Data
//CLASS NAME: Lcrcpt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Lcrcpt : ILcrcpt
	{
		readonly IApplicationDB appDB;
		
		public Lcrcpt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LcrcptSp(
			string TrnitemTrnNum,
			int? TrnitemTrnLine,
			decimal? PQtyShipped,
			DateTime? PTranDate,
			string Infobar)
		{
			TrnNumType _TrnitemTrnNum = TrnitemTrnNum;
			TrnLineType _TrnitemTrnLine = TrnitemTrnLine;
			QtyUnitType _PQtyShipped = PQtyShipped;
			DateType _PTranDate = PTranDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LcrcptSp";
				
				appDB.AddCommandParameter(cmd, "TrnitemTrnNum", _TrnitemTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemTrnLine", _TrnitemTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyShipped", _PQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTranDate", _PTranDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
