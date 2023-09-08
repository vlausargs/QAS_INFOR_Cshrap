//PROJECT NAME: Production
//CLASS NAME: RSQC_Get_Entity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_Get_Entity : IRSQC_Get_Entity
	{
		readonly IApplicationDB appDB;
		
		public RSQC_Get_Entity(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string RSQC_Get_EntityFn(
			string i_ref_type,
			string i_ref_num,
			int? i_ref_line,
			string i_entity)
		{
			QCRefType _i_ref_type = i_ref_type;
			QCDocNumType _i_ref_num = i_ref_num;
			QCRefLineType _i_ref_line = i_ref_line;
			QCDocNumType _i_entity = i_entity;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[RSQC_Get_Entity](@i_ref_type, @i_ref_num, @i_ref_line, @i_entity)";
				
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_num", _i_ref_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_line", _i_ref_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity", _i_entity, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
