//PROJECT NAME: CSIProduct
//CLASS NAME: EcnMassSelected.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IEcnMassSelected
	{
		(int? ReturnCode, int? EcnLineCount, string Infobar) EcnMassSelectedSp(int? SelEcnNum,
		string CurMatl,
		string SubMatl,
		decimal? CurQty,
		decimal? SubQty,
		string CurUM,
		string SubUM,
		string JobType,
		string BeginProductCode,
		string EndProductCode,
		string BeginItem,
		string EndItem,
		DateTime? EffectiveDate,
		string LineStatusDefault,
		string GroupDefault,
		byte? RunMode,
		Guid? PJobmatlRowPointer,
		Guid? PJobRowPointer,
		Guid? PItemRowPointer,
		int? EcnLineCount,
		string Infobar);
	}
	
	public class EcnMassSelected : IEcnMassSelected
	{
		readonly IApplicationDB appDB;
		
		public EcnMassSelected(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? EcnLineCount, string Infobar) EcnMassSelectedSp(int? SelEcnNum,
		string CurMatl,
		string SubMatl,
		decimal? CurQty,
		decimal? SubQty,
		string CurUM,
		string SubUM,
		string JobType,
		string BeginProductCode,
		string EndProductCode,
		string BeginItem,
		string EndItem,
		DateTime? EffectiveDate,
		string LineStatusDefault,
		string GroupDefault,
		byte? RunMode,
		Guid? PJobmatlRowPointer,
		Guid? PJobRowPointer,
		Guid? PItemRowPointer,
		int? EcnLineCount,
		string Infobar)
		{
			EcnNumType _SelEcnNum = SelEcnNum;
			ItemType _CurMatl = CurMatl;
			ItemType _SubMatl = SubMatl;
			QtyPerType _CurQty = CurQty;
			QtyPerType _SubQty = SubQty;
			UMType _CurUM = CurUM;
			UMType _SubUM = SubUM;
			StringType _JobType = JobType;
			ProductCodeType _BeginProductCode = BeginProductCode;
			ProductCodeType _EndProductCode = EndProductCode;
			ItemType _BeginItem = BeginItem;
			ItemType _EndItem = EndItem;
			DateType _EffectiveDate = EffectiveDate;
			EcnItemStatusType _LineStatusDefault = LineStatusDefault;
			EcnGroupType _GroupDefault = GroupDefault;
			ByteType _RunMode = RunMode;
			RowPointerType _PJobmatlRowPointer = PJobmatlRowPointer;
			RowPointerType _PJobRowPointer = PJobRowPointer;
			RowPointerType _PItemRowPointer = PItemRowPointer;
			IntType _EcnLineCount = EcnLineCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcnMassSelectedSp";
				
				appDB.AddCommandParameter(cmd, "SelEcnNum", _SelEcnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurMatl", _CurMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubMatl", _SubMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurQty", _CurQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubQty", _SubQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUM", _CurUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubUM", _SubUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginProductCode", _BeginProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProductCode", _EndProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginItem", _BeginItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineStatusDefault", _LineStatusDefault, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupDefault", _GroupDefault, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunMode", _RunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobmatlRowPointer", _PJobmatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobRowPointer", _PJobRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemRowPointer", _PItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnLineCount", _EcnLineCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EcnLineCount = _EcnLineCount;
				Infobar = _Infobar;
				
				return (Severity, EcnLineCount, Infobar);
			}
		}
	}
}
