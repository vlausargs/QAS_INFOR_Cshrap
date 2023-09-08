//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefTRRData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefTRRData : IRSQC_GetXrefTRRData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetXrefTRRData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefTRRDataSp(string i_trr,
		string o_desc,
		string Infobar)
		{
			QCDocNumType _i_trr = i_trr;
			DescriptionType _o_desc = o_desc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetXrefTRRDataSp";
				
				appDB.AddCommandParameter(cmd, "i_trr", _i_trr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_desc", _o_desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_desc = _o_desc;
				Infobar = _Infobar;
				
				return (Severity, o_desc, Infobar);
			}
		}
	}
}
