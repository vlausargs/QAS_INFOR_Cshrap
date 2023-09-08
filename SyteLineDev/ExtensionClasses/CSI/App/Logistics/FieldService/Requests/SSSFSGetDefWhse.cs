//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSGetDefWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSGetDefWhse
	{
		int SSSFSGetDefWhseSp(string Table,
		                      string IRefType,
		                      string IRefNum,
		                      int? IRefLine,
		                      int? IRefRel,
		                      string IPartnerId,
		                      ref string OWhse,
		                      ref string Infobar);
	}
	
	public class SSSFSGetDefWhse : ISSSFSGetDefWhse
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetDefWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSGetDefWhseSp(string Table,
		                             string IRefType,
		                             string IRefNum,
		                             int? IRefLine,
		                             int? IRefRel,
		                             string IPartnerId,
		                             ref string OWhse,
		                             ref string Infobar)
		{
			StringType _Table = Table;
			LongListType _IRefType = IRefType;
			LongListType _IRefNum = IRefNum;
			GenericNoType _IRefLine = IRefLine;
			GenericNoType _IRefRel = IRefRel;
			FSPartnerType _IPartnerId = IPartnerId;
			WhseType _OWhse = OWhse;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetDefWhseSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRefType", _IRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRefNum", _IRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRefLine", _IRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRefRel", _IRefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IPartnerId", _IPartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OWhse", _OWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OWhse = _OWhse;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
