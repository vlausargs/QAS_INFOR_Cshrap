//PROJECT NAME: Material
//CLASS NAME: PP_ItemUMConvert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PP_ItemUMConvert : IPP_ItemUMConvert
	{
		readonly IApplicationDB appDB;
		
		
		public PP_ItemUMConvert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PP_ItemUMConvertSp(decimal? Length,
		decimal? Width,
		decimal? Density,
		string BaseUM,
		string LengthUM,
		string DensityUM,
		string PaperMassBasis,
		string Item,
		string Infobar)
		{
			PP_OperationDimensionType _Length = Length;
			PP_OperationDimensionType _Width = Width;
			AmountType _Density = Density;
			UMType _BaseUM = BaseUM;
			UMType _LengthUM = LengthUM;
			UMType _DensityUM = DensityUM;
			PP_PaperMassBasisType _PaperMassBasis = PaperMassBasis;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_ItemUMConvertSp";
				
				appDB.AddCommandParameter(cmd, "Length", _Length, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Width", _Width, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Density", _Density, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseUM", _BaseUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LengthUM", _LengthUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DensityUM", _DensityUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaperMassBasis", _PaperMassBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
