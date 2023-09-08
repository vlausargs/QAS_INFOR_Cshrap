//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSInspectionsPreview.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSInspectionsPreview
	{
		int SSSFSInspectionsPreviewSp(string Item,
		                              string InspectType,
		                              ref string Infobar);
	}
	
	public class SSSFSInspectionsPreview : ISSSFSInspectionsPreview
	{
		readonly IApplicationDB appDB;
		
		public SSSFSInspectionsPreview(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSInspectionsPreviewSp(string Item,
		                                     string InspectType,
		                                     ref string Infobar)
		{
			ItemType _Item = Item;
			FSInspectTypeType _InspectType = InspectType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSInspectionsPreviewSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InspectType", _InspectType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
