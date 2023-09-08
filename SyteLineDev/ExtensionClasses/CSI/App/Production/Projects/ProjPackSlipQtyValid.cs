//PROJECT NAME: Production
//CLASS NAME: ProjPackSlipQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjPackSlipQtyValid : IProjPackSlipQtyValid
	{
		readonly IApplicationDB appDB;
		
		
		public ProjPackSlipQtyValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Warning,
		string Infobar) ProjPackSlipQtyValidSp(decimal? QtyRequired,
		decimal? QtyToPack,
		string TPckCall,
		string Warning,
		string Infobar)
		{
			QtyUnitType _QtyRequired = QtyRequired;
			QtyUnitType _QtyToPack = QtyToPack;
			StringType _TPckCall = TPckCall;
			InfobarType _Warning = Warning;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjPackSlipQtyValidSp";
				
				appDB.AddCommandParameter(cmd, "QtyRequired", _QtyRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToPack", _QtyToPack, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Warning", _Warning, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Warning = _Warning;
				Infobar = _Infobar;
				
				return (Severity, Warning, Infobar);
			}
		}
	}
}
