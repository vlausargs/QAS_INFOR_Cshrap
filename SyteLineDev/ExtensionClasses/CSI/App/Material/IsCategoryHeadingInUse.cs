//PROJECT NAME: CSIMaterial
//CLASS NAME: IsCategoryHeadingInUse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IIsCategoryHeadingInUse
	{
		int IsCategoryHeadingInUseSp(string ItemCategory,
		                             ref byte? IsCategoryHeadingInUse,
		                             ref string Infobar);
	}
	
	public class IsCategoryHeadingInUse : IIsCategoryHeadingInUse
	{
		readonly IApplicationDB appDB;
		
		public IsCategoryHeadingInUse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int IsCategoryHeadingInUseSp(string ItemCategory,
		                                    ref byte? IsCategoryHeadingInUse,
		                                    ref string Infobar)
		{
			ItemCategoryType _ItemCategory = ItemCategory;
			ListYesNoType _IsCategoryHeadingInUse = IsCategoryHeadingInUse;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsCategoryHeadingInUseSp";
				
				appDB.AddCommandParameter(cmd, "ItemCategory", _ItemCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsCategoryHeadingInUse", _IsCategoryHeadingInUse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsCategoryHeadingInUse = _IsCategoryHeadingInUse;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
