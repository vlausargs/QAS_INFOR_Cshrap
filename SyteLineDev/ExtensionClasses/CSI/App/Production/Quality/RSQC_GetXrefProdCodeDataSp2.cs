//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefProdCodeData2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefProdCodeData2 : IRSQC_GetXrefProdCodeData2
	{
		readonly IApplicationDB appDB;
		
		public RSQC_GetXrefProdCodeData2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string o_desc,
			string Infobar) RSQC_GetXrefProdCodeDataSp2(
			string i_prodcode,
			string o_desc,
			string Infobar)
		{
			ProductCodeType _i_prodcode = i_prodcode;
			DescriptionType _o_desc = o_desc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetXrefProdCodeDataSp2";
				
				appDB.AddCommandParameter(cmd, "i_prodcode", _i_prodcode, ParameterDirection.Input);
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
