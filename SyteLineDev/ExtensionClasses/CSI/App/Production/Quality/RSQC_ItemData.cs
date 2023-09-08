//PROJECT NAME: Production
//CLASS NAME: RSQC_ItemData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ItemData : IRSQC_ItemData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_ItemData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string i_Description,
		string i_UM,
		int? i_LotTracked,
		int? i_SerialTracked,
		string Infobar) RSQC_ItemDataSp(string i_Item,
		string i_Description,
		string i_UM,
		int? i_LotTracked,
		int? i_SerialTracked,
		string Infobar)
		{
			ItemType _i_Item = i_Item;
			DescriptionType _i_Description = i_Description;
			UMType _i_UM = i_UM;
			ListYesNoType _i_LotTracked = i_LotTracked;
			ListYesNoType _i_SerialTracked = i_SerialTracked;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ItemDataSp";
				
				appDB.AddCommandParameter(cmd, "i_Item", _i_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Description", _i_Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "i_UM", _i_UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "i_LotTracked", _i_LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "i_SerialTracked", _i_SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				i_Description = _i_Description;
				i_UM = _i_UM;
				i_LotTracked = _i_LotTracked;
				i_SerialTracked = _i_SerialTracked;
				Infobar = _Infobar;
				
				return (Severity, i_Description, i_UM, i_LotTracked, i_SerialTracked, Infobar);
			}
		}
	}
}
