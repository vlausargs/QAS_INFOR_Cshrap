//PROJECT NAME: CSIProduct
//CLASS NAME: EcnMass.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IEcnMass
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) EcnMassSp(int? SelEcnNum,
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
		string Infobar);
	}
	
	public class EcnMass : IEcnMass
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public EcnMass(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) EcnMassSp(int? SelEcnNum,
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
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcnMassSp";
				
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
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
