using System;

namespace ERPSupport.DALFacorty.INOrder
{
    using IDAL.INOrder;
    using SQL.INOrder;

    /// <summary>
    /// Factory
    /// </summary>
    public static class DALCreater
    {
        public static IOrder CommFunction
        {
            get
            {
                return new CommFunction();
            }
        }
    }
}
