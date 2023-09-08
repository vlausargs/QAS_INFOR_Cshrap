//PROJECT NAME: Data
//CLASS NAME: CurrCnvtSingleAmt2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class CurrCnvtSingleAmt2Factory : ICurrCnvtSingleAmt2Factory
	{
		public ICurrCnvtSingleAmt2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CurrCnvtSingleAmt2 = new CurrCnvtSingleAmt2(appDB);


			return _CurrCnvtSingleAmt2;
		}
        public ICurrCnvtSingleAmt2 Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _CurrCnvtSingleAmt2 = new Finance.CurrCnvtSingleAmt2(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCurrCnvtSingleAmt2Ext = timerfactory.Create<Finance.ICurrCnvtSingleAmt2>(_CurrCnvtSingleAmt2);

            return iCurrCnvtSingleAmt2Ext;
        }
    }
}
