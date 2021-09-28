using System;
using System.Collections;
using System.Collections.Generic;

namespace Proxy
{
    public class Monster
    {
        public byte Age;
        public int X, Y;
    }

    public class Monsters
    {
        private readonly int size;

        private byte[] age;
        private int[] x, y;

        public Monsters(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct MonsterProxy
        {
            private readonly Monsters monsters;
            private readonly int index;


            public MonsterProxy(Monsters monsters, int index)
            {
                this.monsters = monsters;
                this.index = index;
            }

            public ref byte Age => ref monsters.age[index];
            public ref int X => ref monsters.x[index];
            public ref int Y => ref monsters.y[index];

        }

        public IEnumerator<MonsterProxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; ++pos)
            {
                yield return new MonsterProxy(this, pos);
            }
        }

    }

}
