//PROJECT NAME: Finance
//CLASS NAME: GetInitialFaDisp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetInitialFaDisp : IGetInitialFaDisp
	{
		readonly IApplicationDB appDB;
		
		
		public GetInitialFaDisp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rGLAsstAcct,
		string rGLAsstUnit1,
		string rGLAsstUnit2,
		string rGLAsstUnit3,
		string rGLAsstUnit4,
		string rGLResAcct,
		string rGLResUnit1,
		string rGLResUnit2,
		string rGLResUnit3,
		string rGLResUnit4,
		decimal? rFadeprBonusDepr,
		decimal? rFadeprAccumDepr,
		string Infobar) GetInitialFaDispSp(string pFaNum,
		string pClass,
		string pDept,
		string rGLAsstAcct,
		string rGLAsstUnit1,
		string rGLAsstUnit2,
		string rGLAsstUnit3,
		string rGLAsstUnit4,
		string rGLResAcct,
		string rGLResUnit1,
		string rGLResUnit2,
		string rGLResUnit3,
		string rGLResUnit4,
		decimal? rFadeprBonusDepr,
		decimal? rFadeprAccumDepr,
		string Infobar)
		{
			FaNumType _pFaNum = pFaNum;
			FaClassType _pClass = pClass;
			DeptType _pDept = pDept;
			AcctType _rGLAsstAcct = rGLAsstAcct;
			UnitCode1Type _rGLAsstUnit1 = rGLAsstUnit1;
			UnitCode2Type _rGLAsstUnit2 = rGLAsstUnit2;
			UnitCode3Type _rGLAsstUnit3 = rGLAsstUnit3;
			UnitCode4Type _rGLAsstUnit4 = rGLAsstUnit4;
			AcctType _rGLResAcct = rGLResAcct;
			UnitCode1Type _rGLResUnit1 = rGLResUnit1;
			UnitCode2Type _rGLResUnit2 = rGLResUnit2;
			UnitCode3Type _rGLResUnit3 = rGLResUnit3;
			UnitCode4Type _rGLResUnit4 = rGLResUnit4;
			AmountType _rFadeprBonusDepr = rFadeprBonusDepr;
			AmountType _rFadeprAccumDepr = rFadeprAccumDepr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetInitialFaDispSp";
				
				appDB.AddCommandParameter(cmd, "pFaNum", _pFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pClass", _pClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDept", _pDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rGLAsstAcct", _rGLAsstAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAsstUnit1", _rGLAsstUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAsstUnit2", _rGLAsstUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAsstUnit3", _rGLAsstUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAsstUnit4", _rGLAsstUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLResAcct", _rGLResAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLResUnit1", _rGLResUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLResUnit2", _rGLResUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLResUnit3", _rGLResUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLResUnit4", _rGLResUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rFadeprBonusDepr", _rFadeprBonusDepr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rFadeprAccumDepr", _rFadeprAccumDepr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rGLAsstAcct = _rGLAsstAcct;
				rGLAsstUnit1 = _rGLAsstUnit1;
				rGLAsstUnit2 = _rGLAsstUnit2;
				rGLAsstUnit3 = _rGLAsstUnit3;
				rGLAsstUnit4 = _rGLAsstUnit4;
				rGLResAcct = _rGLResAcct;
				rGLResUnit1 = _rGLResUnit1;
				rGLResUnit2 = _rGLResUnit2;
				rGLResUnit3 = _rGLResUnit3;
				rGLResUnit4 = _rGLResUnit4;
				rFadeprBonusDepr = _rFadeprBonusDepr;
				rFadeprAccumDepr = _rFadeprAccumDepr;
				Infobar = _Infobar;
				
				return (Severity, rGLAsstAcct, rGLAsstUnit1, rGLAsstUnit2, rGLAsstUnit3, rGLAsstUnit4, rGLResAcct, rGLResUnit1, rGLResUnit2, rGLResUnit3, rGLResUnit4, rFadeprBonusDepr, rFadeprAccumDepr, Infobar);
			}
		}
	}
}
