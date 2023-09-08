//PROJECT NAME: BusInterface
//CLASS NAME: SerialSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class SerialSave : ISerialSave
	{
		readonly IApplicationDB appDB;
		
		
		public SerialSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SerialSaveSp(string SerNum,
		Guid? TmpSerId = null,
		string RefStr = null,
		string Infobar = null,
		DateTime? ManufacturedDate = null,
		DateTime? ExpirationDate = null,
		string TrxRestrictCode = null)
		{
			SerNumType _SerNum = SerNum;
			RowPointerType _TmpSerId = TmpSerId;
			RefStrType _RefStr = RefStr;
			InfobarType _Infobar = Infobar;
			DateType _ManufacturedDate = ManufacturedDate;
			DateType _ExpirationDate = ExpirationDate;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SerialSaveSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpSerId", _TmpSerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStr", _RefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturedDate", _ManufacturedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpirationDate", _ExpirationDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
