//PROJECT NAME: DataCollection
//CLASS NAME: Getumcf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class Getumcf : IGetumcf
	{
		readonly IApplicationDB appDB;
		
		
		public Getumcf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ConvFactor,
		string Infobar) GetumcfSp(string OtherUM,
		string Item,
		string VendNum,
		string Area,
		decimal? ConvFactor,
		string Infobar,
		string Site = null)
		{
			UMType _OtherUM = OtherUM;
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			LongList _Area = Area;
			UMConvFactorType _ConvFactor = ConvFactor;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetumcfSp";
				
				appDB.AddCommandParameter(cmd, "OtherUM", _OtherUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Area", _Area, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ConvFactor = _ConvFactor;
				Infobar = _Infobar;
				
				return (Severity, ConvFactor, Infobar);
			}
		}


        public decimal? GetumcfFn(
            string OtherUM,
            string Item,
            string VendNum,
            string Area)
        {
            UMType _OtherUM = OtherUM;
            ItemType _Item = Item;
            VendNumType _VendNum = VendNum;
            StringType _Area = Area;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[Getumcf](@OtherUM, @Item, @VendNum, @Area)";

                appDB.AddCommandParameter(cmd, "OtherUM", _OtherUM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Area", _Area, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<decimal?>(cmd);

                return Output;
            }
        }
    }

}
