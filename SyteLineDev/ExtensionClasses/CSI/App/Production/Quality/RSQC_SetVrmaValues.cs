//PROJECT NAME: Production
//CLASS NAME: RSQC_SetVrmaValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetVrmaValues : IRSQC_SetVrmaValues
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SetVrmaValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_SetVrmaValuesSp(int? i_vrma,
		string i_type,
		decimal? i_qty,
		int? qcscrapadjust = 0,
		int? qcreturnadjust = 0,
		int? qcreceiveadjust = 0,
		string Infobar = null)
		{
			QCRcvrNumType _i_vrma = i_vrma;
			StringType _i_type = i_type;
			QtyUnitType _i_qty = i_qty;
			ListYesNoType _qcscrapadjust = qcscrapadjust;
			ListYesNoType _qcreturnadjust = qcreturnadjust;
			ListYesNoType _qcreceiveadjust = qcreceiveadjust;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SetVrmaValuesSp";
				
				appDB.AddCommandParameter(cmd, "i_vrma", _i_vrma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_type", _i_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_qty", _i_qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qcscrapadjust", _qcscrapadjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qcreturnadjust", _qcreturnadjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qcreceiveadjust", _qcreceiveadjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
