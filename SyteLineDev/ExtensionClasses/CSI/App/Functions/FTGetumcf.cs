//PROJECT NAME: Data
//CLASS NAME: FTGetumcf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTGetumcf : IFTGetumcf
	{
		readonly IApplicationDB appDB;
		
		public FTGetumcf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? FTGetumcfFn(
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
				cmd.CommandText = "SELECT  dbo.[FTGetumcf](@OtherUM, @Item, @VendNum, @Area)";
				
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
