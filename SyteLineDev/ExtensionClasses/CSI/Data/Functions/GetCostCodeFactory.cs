//PROJECT NAME: Data
//CLASS NAME: GetCostCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class GetCostCodeFactory
    {
        public IGetCostCode Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var _GetCostCode = new Functions.GetCostCode(appDB);

            return _GetCostCode;
        }
    }
}
