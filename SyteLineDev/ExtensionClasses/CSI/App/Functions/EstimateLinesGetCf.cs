//PROJECT NAME: Data
//CLASS NAME: EstimateLinesGetCf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EstimateLinesGetCf : IEstimateLinesGetCf
	{
		readonly IApplicationDB appDB;
		
		public EstimateLinesGetCf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? UomConvFactor,
			decimal? QtyOrderedBase,
			string Infobar) EstimateLinesGetCfSp(
			string UM,
			string Item,
			string CustNum,
			decimal? QtyOrdered,
			decimal? UomConvFactor,
			decimal? QtyOrderedBase,
			string Infobar)
		{
			ItemType _UM = UM;
			ItemType _Item = Item;
			ItemType _CustNum = CustNum;
			QtyUnitType _QtyOrdered = QtyOrdered;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			QtyUnitType _QtyOrderedBase = QtyOrderedBase;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesGetCfSp";
				
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOrderedBase", _QtyOrderedBase, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UomConvFactor = _UomConvFactor;
				QtyOrderedBase = _QtyOrderedBase;
				Infobar = _Infobar;
				
				return (Severity, UomConvFactor, QtyOrderedBase, Infobar);
			}
		}
	}
}
