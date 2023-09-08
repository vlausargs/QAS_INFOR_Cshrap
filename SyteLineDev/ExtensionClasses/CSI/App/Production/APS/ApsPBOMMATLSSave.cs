//PROJECT NAME: Production
//CLASS NAME: ApsPBOMMATLSSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPBOMMATLSSave : IApsPBOMMATLSSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsPBOMMATLSSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPBOMMATLSSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		string MATERIALID,
		int? SEQNO,
		int? BOMFLAGS,
		decimal? QUANTITY,
		int? MERGETO,
		decimal? SHRINK,
		int? ALTID,
		string REFORDERID,
		DateTime? EFFDATE,
		DateTime? OBSDATE)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsPbomType _BOMID = BOMID;
			ApsMaterialType _MATERIALID = MATERIALID;
			ApsIntType _SEQNO = SEQNO;
			ApsBitFlagsType _BOMFLAGS = BOMFLAGS;
			ApsFloatType _QUANTITY = QUANTITY;
			ApsIntType _MERGETO = MERGETO;
			ApsMultiplierType _SHRINK = SHRINK;
			ApsIntType _ALTID = ALTID;
			ApsOrderType _REFORDERID = REFORDERID;
			DateTimeType _EFFDATE = EFFDATE;
			DateTimeType _OBSDATE = OBSDATE;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsPBOMMATLSSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMID", _BOMID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SEQNO", _SEQNO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMFLAGS", _BOMFLAGS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QUANTITY", _QUANTITY, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MERGETO", _MERGETO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHRINK", _SHRINK, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALTID", _ALTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "REFORDERID", _REFORDERID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFFDATE", _EFFDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OBSDATE", _OBSDATE, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
