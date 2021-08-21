using System;
using System.Threading.Tasks;
using static System.Console;

namespace Factory
{
    public class Foo
    {
        private Foo() // make the constructor private
        {
            //await Task.Delay(1000); //? impossible
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }
}
