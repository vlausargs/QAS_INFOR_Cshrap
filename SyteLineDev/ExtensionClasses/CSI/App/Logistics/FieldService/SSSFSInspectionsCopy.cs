//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSInspectionsCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSInspectionsCopy
	{
		int SSSFSInspectionsCopySp(string FromItem,
		                           string FromInspectType,
		                           string FromSectionCode,
		                           string ToItem,
		                           string ToInspectType,
		                           string ToSectionCode,
		                           ref string Infobar);
	}
	
	public class SSSFSInspectionsCopy : ISSSFSInspectionsCopy
	{
		readonly IApplicationDB appDB;
		
		public SSSFSInspectionsCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSInspectionsCopySp(string FromItem,
		                                  string FromInspectType,
		                                  string FromSectionCode,
		                                  string ToItem,
		                                  string ToInspectType,
		                                  string ToSectionCode,
		                                  ref string Infobar)
		{
			ItemType _FromItem = FromItem;
			FSInspectTypeType _FromInspectType = FromInspectType;
			FSSectionCodeType _FromSectionCode = FromSectionCode;
			ItemType _ToItem = ToItem;
			FSInspectTypeType _ToInspectType = ToInspectType;
			FSSectionCodeType _ToSectionCode = ToSectionCode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSInspectionsCopySp";
				
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromInspectType", _FromInspectType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSectionCode", _FromSectionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToInspectType", _ToInspectType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSectionCode", _ToSectionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
