//PROJECT NAME: Data
//CLASS NAME: PrintW2Forms_SetBox12.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PrintW2Forms_SetBox12 : IPrintW2Forms_SetBox12
	{
		readonly IApplicationDB appDB;
		
		public PrintW2Forms_SetBox12(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ie,
			string t_box12__1,
			string t_box12__2,
			string t_box12__3,
			string t_box12__4,
			decimal? t_box12_itemz__1,
			decimal? t_box12_itemz__2,
			decimal? t_box12_itemz__3,
			decimal? t_box12_itemz__4) PrintW2Forms_SetBox12Sp(
			int? index,
			int? ie,
			string t_box12__1,
			string t_box12__2,
			string t_box12__3,
			string t_box12__4,
			decimal? t_box12_itemz__1,
			decimal? t_box12_itemz__2,
			decimal? t_box12_itemz__3,
			decimal? t_box12_itemz__4,
			decimal? t_itemz)
		{
			IntType _index = index;
			IntType _ie = ie;
			StringType _t_box12__1 = t_box12__1;
			StringType _t_box12__2 = t_box12__2;
			StringType _t_box12__3 = t_box12__3;
			StringType _t_box12__4 = t_box12__4;
			PrYtdAmountType _t_box12_itemz__1 = t_box12_itemz__1;
			PrYtdAmountType _t_box12_itemz__2 = t_box12_itemz__2;
			PrYtdAmountType _t_box12_itemz__3 = t_box12_itemz__3;
			PrYtdAmountType _t_box12_itemz__4 = t_box12_itemz__4;
			PrYtdAmountType _t_itemz = t_itemz;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintW2Forms_SetBox12Sp";
				
				appDB.AddCommandParameter(cmd, "index", _index, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ie", _ie, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_box12##1", _t_box12__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_box12##2", _t_box12__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_box12##3", _t_box12__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_box12##4", _t_box12__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_box12_itemz##1", _t_box12_itemz__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_box12_itemz##2", _t_box12_itemz__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_box12_itemz##3", _t_box12_itemz__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_box12_itemz##4", _t_box12_itemz__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_itemz", _t_itemz, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ie = _ie;
				t_box12__1 = _t_box12__1;
				t_box12__2 = _t_box12__2;
				t_box12__3 = _t_box12__3;
				t_box12__4 = _t_box12__4;
				t_box12_itemz__1 = _t_box12_itemz__1;
				t_box12_itemz__2 = _t_box12_itemz__2;
				t_box12_itemz__3 = _t_box12_itemz__3;
				t_box12_itemz__4 = _t_box12_itemz__4;
				
				return (Severity, ie, t_box12__1, t_box12__2, t_box12__3, t_box12__4, t_box12_itemz__1, t_box12_itemz__2, t_box12_itemz__3, t_box12_itemz__4);
			}
		}
	}
}
