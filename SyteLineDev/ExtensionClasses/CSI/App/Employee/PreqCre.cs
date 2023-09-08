//PROJECT NAME: Employee
//CLASS NAME: PreqCre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PreqCre : IPreqCre
	{
		readonly IApplicationDB appDB;
		
		
		public PreqCre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? I,
		string CurReqNum,
		int? CurReqLine,
		string Infobar) PreqCreSp(string IItem,
		string IWhse,
		string IReqNum,
		decimal? IQtyOrdered,
		DateTime? IDueDate,
		string IRefType,
		string IRefNum,
		int? IRefLineSuf,
		int? IRefRelease,
		string IDesc,
		decimal? ICost,
		string IUM,
		string IVendNum,
		string IManufacturerId = null,
		string IManufacturerItem = null,
		int? I = null,
		string CurReqNum = null,
		int? CurReqLine = null,
		string Infobar = null)
		{
			ItemType _IItem = IItem;
			WhseType _IWhse = IWhse;
			ReqNumType _IReqNum = IReqNum;
			QtyUnitNoNegType _IQtyOrdered = IQtyOrdered;
			DateType _IDueDate = IDueDate;
			RefTypeIJKOTType _IRefType = IRefType;
			CoJobProjTrnNumType _IRefNum = IRefNum;
			CoLineSuffixProjTaskTrnLineType _IRefLineSuf = IRefLineSuf;
			CoReleaseOperNumType _IRefRelease = IRefRelease;
			DescriptionType _IDesc = IDesc;
			CostPrcType _ICost = ICost;
			UMType _IUM = IUM;
			VendNumType _IVendNum = IVendNum;
			ManufacturerIdType _IManufacturerId = IManufacturerId;
			ManufacturerItemType _IManufacturerItem = IManufacturerItem;
			GenericNoType _I = I;
			PoNumType _CurReqNum = CurReqNum;
			PoLineType _CurReqLine = CurReqLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreqCreSp";
				
				appDB.AddCommandParameter(cmd, "IItem", _IItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IWhse", _IWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IReqNum", _IReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IQtyOrdered", _IQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IDueDate", _IDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRefType", _IRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRefNum", _IRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRefLineSuf", _IRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRefRelease", _IRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IDesc", _IDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ICost", _ICost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUM", _IUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IVendNum", _IVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IManufacturerId", _IManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IManufacturerItem", _IManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "I", _I, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurReqNum", _CurReqNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurReqLine", _CurReqLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				I = _I;
				CurReqNum = _CurReqNum;
				CurReqLine = _CurReqLine;
				Infobar = _Infobar;
				
				return (Severity, I, CurReqNum, CurReqLine, Infobar);
			}
		}
	}
}
