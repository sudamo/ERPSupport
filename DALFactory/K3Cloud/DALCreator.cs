using System;

namespace ERPSupport.DALFactory.K3Cloud
{
    using IDAL.K3Cloud;
    using SQL.K3Cloud;

    /// <summary>
    /// Factory
    /// </summary>
    public static class DALCreator
    {
        public static ICommFunction CommFunction
        {
            get { return new CommFunction(); }
        }
        public static IFileSetting FileSetting
        {
            get { return new FileSetting(); }
        }
        public static IPrdAllocation PrdAllocation
        {
            get { return new PrdAllocation(); }
        }
        public static IPrdInstock PrdInstock
        {
            get { return new PrdInstock(); }
        }
        public static IPrdOutstock PrdOutstock
        {
            get { return new PrdOutstock(); }
        }
        public static IPrdPick PrdPick
        {
            get { return new PrdPick(); }
        }
        public static ISalOrder SalOrder
        {
            get { return new SalOrder(); }
        }
    }
}
