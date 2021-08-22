using System;
using System.Text;
using System.Threading;
//using JetBrains.Annotations;

namespace Singleton
{
    //Lazy<T> : gives us two things
    //1. (obvs) Laziness
    //2. thread safety during initialization
    //[ThreadStatic] or ThreadLocal<>

    public sealed class PerThreadSingleton
    {
        private static ThreadLocal<PerThreadSingleton> threadInstance = 
        new ThreadLocal<PerThreadSingleton>(
            () => new PerThreadSingleton()
        );

        public int Id;

        private PerThreadSingleton()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }

        public static PerThreadSingleton ThreadInstance => threadInstance.Value;
    }
}
