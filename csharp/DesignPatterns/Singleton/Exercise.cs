using System;

namespace Singleton
{
    public class SingletonTester
    {
      public static bool IsSingleton(Func<object> func)
      {
        // todo
        var f1 = func();
        var f2 = func();
        return f1 == f2;
      }
    }
}
