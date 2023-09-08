//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteShiftException.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IDeleteShiftException
	{
		(int? ReturnCode, string Infobar) DeleteShiftExceptionSP(string FromResource,
		string ToResource,
		DateTime? FromStartTime,
		DateTime? ToStartTime,
		string Exception,
		short? AltNo,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null);
	}
	
	public class DeleteShiftException : IDeleteShiftException
	{
		readonly IApplicationDB appDB;
		
		public DeleteShiftException(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteShiftExceptionSP(string FromResource,
		string ToResource,
		DateTime? FromStartTime,
		DateTime? ToStartTime,
		string Exception,
		short? AltNo,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null)
		{
			ApsRestypeType _FromResource = FromResource;
			ApsRestypeType _ToResource = ToResource;
			DateTimeType _FromStartTime = FromStartTime;
			DateTimeType _ToStartTime = ToStartTime;
			ApsShiftType _Exception = Exception;
			ApsAltNoType _AltNo = AltNo;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteShiftExceptionSP";
				
				appDB.AddCommandParameter(cmd, "FromResource", _FromResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToResource", _ToResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromStartTime", _FromStartTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToStartTime", _ToStartTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Exception", _Exception, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
