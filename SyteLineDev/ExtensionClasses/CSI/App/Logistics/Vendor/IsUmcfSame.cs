//PROJECT NAME: CSIVendor
//CLASS NAME: IsUmcfSame.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IIsUmcfSame
	{
		int IsUmcfSameSp(string OtherUM,
		                 string Item,
		                 string VendNum,
		                 string Area,
		                 string FromSite,
		                 string ToSite,
		                 ref string Infobar);
	}
	
	public class IsUmcfSame : IIsUmcfSame
	{
		readonly IApplicationDB appDB;
		
		public IsUmcfSame(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int IsUmcfSameSp(string OtherUM,
		                        string Item,
		                        string VendNum,
		                        string Area,
		                        string FromSite,
		                        string ToSite,
		                        ref string Infobar)
		{
			UMType _OtherUM = OtherUM;
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			LongList _Area = Area;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsUmcfSameSp";
				
				appDB.AddCommandParameter(cmd, "OtherUM", _OtherUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Area", _Area, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
