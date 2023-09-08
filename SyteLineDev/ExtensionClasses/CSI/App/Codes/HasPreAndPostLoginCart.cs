//PROJECT NAME: CSICodes
//CLASS NAME: HasPreAndPostLoginCart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IHasPreAndPostLoginCart
	{
		int HasPreAndPostLoginCartSp(Guid? CoRowPointer,
		                             ref string GlobalCustNum,
		                             ref string GlobalUserId,
		                             ref byte? GlobalIsPreLogin,
		                             ref string ToOrderType,
		                             ref byte? MergeCart,
		                             ref byte? HasConfig,
		                             ref string PreLoginCoNum,
		                             ref string PostLoginCoNum,
		                             ref string GlobalPrimarySite,
		                             ref string Infobar);
	}
	
	public class HasPreAndPostLoginCart : IHasPreAndPostLoginCart
	{
		readonly IApplicationDB appDB;
		
		public HasPreAndPostLoginCart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int HasPreAndPostLoginCartSp(Guid? CoRowPointer,
		                                    ref string GlobalCustNum,
		                                    ref string GlobalUserId,
		                                    ref byte? GlobalIsPreLogin,
		                                    ref string ToOrderType,
		                                    ref byte? MergeCart,
		                                    ref byte? HasConfig,
		                                    ref string PreLoginCoNum,
		                                    ref string PostLoginCoNum,
		                                    ref string GlobalPrimarySite,
		                                    ref string Infobar)
		{
			RowPointerType _CoRowPointer = CoRowPointer;
			CustNumType _GlobalCustNum = GlobalCustNum;
			UsernameType _GlobalUserId = GlobalUserId;
			ListYesNoType _GlobalIsPreLogin = GlobalIsPreLogin;
			CoTypeType _ToOrderType = ToOrderType;
			ListYesNoType _MergeCart = MergeCart;
			ListYesNoType _HasConfig = HasConfig;
			CoNumType _PreLoginCoNum = PreLoginCoNum;
			CoNumType _PostLoginCoNum = PostLoginCoNum;
			SiteType _GlobalPrimarySite = GlobalPrimarySite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HasPreAndPostLoginCartSp";
				
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GlobalCustNum", _GlobalCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalUserId", _GlobalUserId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalIsPreLogin", _GlobalIsPreLogin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToOrderType", _ToOrderType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MergeCart", _MergeCart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HasConfig", _HasConfig, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreLoginCoNum", _PreLoginCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostLoginCoNum", _PostLoginCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalPrimarySite", _GlobalPrimarySite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GlobalCustNum = _GlobalCustNum;
				GlobalUserId = _GlobalUserId;
				GlobalIsPreLogin = _GlobalIsPreLogin;
				ToOrderType = _ToOrderType;
				MergeCart = _MergeCart;
				HasConfig = _HasConfig;
				PreLoginCoNum = _PreLoginCoNum;
				PostLoginCoNum = _PostLoginCoNum;
				GlobalPrimarySite = _GlobalPrimarySite;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
