//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateCmr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateCmr : IRSQC_CreateCmr
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateCmr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_cmr,
		string Infobar) RSQC_CreateCmrSp(int? i_crcvr,
		string i_note,
		string o_cmr,
		string Infobar)
		{
			QCRcvrNumType _i_crcvr = i_crcvr;
			StringType _i_note = i_note;
			QCDocNumType _o_cmr = o_cmr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateCmrSp";
				
				appDB.AddCommandParameter(cmd, "i_crcvr", _i_crcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_note", _i_note, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_cmr", _o_cmr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_cmr = _o_cmr;
				Infobar = _Infobar;
				
				return (Severity, o_cmr, Infobar);
			}
		}
	}
}
