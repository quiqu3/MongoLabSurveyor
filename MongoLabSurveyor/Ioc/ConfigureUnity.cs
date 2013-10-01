using MongoLabSurveyor.Unity;

namespace MongoLabSurveyor.Ioc
{
    public class ConfigureUnity
    {
        static ConfigureUnity()
        {
            UnityHelper.RegisterTypes(UnityHelper.GetConfiguredContainer());
        }
    }
}
