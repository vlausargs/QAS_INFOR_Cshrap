//PROJECT NAME: Data
//CLASS NAME: ItemUm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemUm : IItemUm
	{
		readonly IApplicationDB appDB;
		
		public ItemUm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PUm,
			decimal? PUomConvFactor,
			string Infobar) ItemUmSp(
			string PItem,
			string PUm,
			decimal? PUomConvFactor,
			string Infobar)
		{
			ItemType _PItem = PItem;
			UMType _PUm = PUm;
			UMConvFactorType _PUomConvFactor = PUomConvFactor;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemUmSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUm", _PUm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUomConvFactor", _PUomConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUm = _PUm;
				PUomConvFactor = _PUomConvFactor;
				Infobar = _Infobar;
				
				return (Severity, PUm, PUomConvFactor, Infobar);
			}
		}
	}
}
