//PROJECT NAME: Production
//CLASS NAME: RSQC_GetItemData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetItemData : IRSQC_GetItemData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetItemData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_UM,
		string o_revision,
		string o_drawing_nbr,
		string Infobar) RSQC_GetItemDataSp(string i_item,
		string o_UM,
		string o_revision,
		string o_drawing_nbr,
		string Infobar)
		{
			ItemType _i_item = i_item;
			UMType _o_UM = o_UM;
			RevisionType _o_revision = o_revision;
			DrawingNbrType _o_drawing_nbr = o_drawing_nbr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetItemDataSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_UM", _o_UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_revision", _o_revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_drawing_nbr", _o_drawing_nbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_UM = _o_UM;
				o_revision = _o_revision;
				o_drawing_nbr = _o_drawing_nbr;
				Infobar = _Infobar;
				
				return (Severity, o_UM, o_revision, o_drawing_nbr, Infobar);
			}
		}
	}
}
