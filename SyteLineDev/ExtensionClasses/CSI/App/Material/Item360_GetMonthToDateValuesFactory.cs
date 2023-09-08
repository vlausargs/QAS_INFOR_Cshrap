//PROJECT NAME: CSIMaterial
//CLASS NAME: Item360_GetMonthToDateValuesFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class Item360_GetMonthToDateValuesFactory
    {
        public IItem360_GetMonthToDateValues Create(IApplicationDB appDB)
        {
            var _Item360_GetMonthToDateValues = new Item360_GetMonthToDateValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItem360_GetMonthToDateValuesExt = timerfactory.Create<IItem360_GetMonthToDateValues>(_Item360_GetMonthToDateValues);

            return iItem360_GetMonthToDateValuesExt;
        }
    }
}
