//PROJECT NAME: Material
//CLASS NAME: MrpParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpParm : IMrpParm
	{
		readonly IApplicationDB appDB;
		
		public MrpParm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TFcstAhd,
			int? TFcstBhd,
			int? TExcAhd,
			int? TExcBhd,
			int? TExcAhdJ,
			int? TExcBhdJ,
			string Infobar) MrpParmSp(
			string PrevProd,
			int? TFcstAhd,
			int? TFcstBhd,
			int? TExcAhd,
			int? TExcBhd,
			int? TExcAhdJ,
			int? TExcBhdJ,
			string Infobar)
		{
			ProductCodeType _PrevProd = PrevProd;
			PlanFenceType _TFcstAhd = TFcstAhd;
			PlanFenceType _TFcstBhd = TFcstBhd;
			PlanFenceType _TExcAhd = TExcAhd;
			PlanFenceType _TExcBhd = TExcBhd;
			PlanFenceType _TExcAhdJ = TExcAhdJ;
			PlanFenceType _TExcBhdJ = TExcBhdJ;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpParmSp";
				
				appDB.AddCommandParameter(cmd, "PrevProd", _PrevProd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TFcstAhd", _TFcstAhd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TFcstBhd", _TFcstBhd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TExcAhd", _TExcAhd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TExcBhd", _TExcBhd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TExcAhdJ", _TExcAhdJ, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TExcBhdJ", _TExcBhdJ, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TFcstAhd = _TFcstAhd;
				TFcstBhd = _TFcstBhd;
				TExcAhd = _TExcAhd;
				TExcBhd = _TExcBhd;
				TExcAhdJ = _TExcAhdJ;
				TExcBhdJ = _TExcBhdJ;
				Infobar = _Infobar;
				
				return (Severity, TFcstAhd, TFcstBhd, TExcAhd, TExcBhd, TExcAhdJ, TExcBhdJ, Infobar);
			}
		}
	}
}
