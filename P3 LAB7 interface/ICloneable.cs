using System;
using System.Collections.Generic;
using System.Text;

namespace P3_LAB7_interface
{
    interface ICloneable
    {
        public object Clone();

        public void CheckCode();

        public int Id { get; }
        public string VaultName { get; set; }
        public int[] Code { get; set; }
    }
}
