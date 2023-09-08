//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateCar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateCar : IRSQC_CreateCar
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateCar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_car,
		string Infobar) RSQC_CreateCarSp(string i_mrr,
		string i_crcvr,
		string i_trcvr,
		string i_car,
		string o_car,
		string Infobar)
		{
			QCDocNumType _i_mrr = i_mrr;
			QCDocNumType _i_crcvr = i_crcvr;
			QCDocNumType _i_trcvr = i_trcvr;
			QCDocNumType _i_car = i_car;
			QCDocNumType _o_car = o_car;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateCarSp";
				
				appDB.AddCommandParameter(cmd, "i_mrr", _i_mrr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_crcvr", _i_crcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_trcvr", _i_trcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_car", _i_car, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_car", _o_car, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_car = _o_car;
				Infobar = _Infobar;
				
				return (Severity, o_car, Infobar);
			}
		}
	}
}
