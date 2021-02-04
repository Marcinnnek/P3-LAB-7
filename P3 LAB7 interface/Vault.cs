using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P3_LAB7_interface
{
    class Vault : ICloneable, IPrint, IComparable<Vault>
    {
        public void Print()
        { 
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nazwa: {VaultName}");
            foreach (var item in _code)
            {
                Console.Write(item+", ");
            }
            Console.WriteLine();
        }

        public int CompareTo(Vault other)
        {
            if (other == null) return 1;
            return VaultName.CompareTo(other.VaultName);
         }


        public override string ToString()
        {
            return ($"{VaultName}");
        }
        public object Clone()
        {
            var data = new Vault()
            {
                _ownId = this._ownId,
                _vaultName = this._vaultName,
                _code = (int[])this._code.Clone()
            };
            return data;
        }

        private static int _staticId;
        private int _ownId;
        private string _vaultName;
        private int[] _code = new int[10];

        public Vault()
        {
            int[] code = new int[10];

            Random rnd = new Random();
            for (int i = 0; i < code.Length; i++)
            {
                code[i] = (int)rnd.Next() % 100;
            }
            _code = code;
        }

        public Vault(string vaultName, int[] code)
        {
            _staticId++;
            _ownId = _staticId;
            _vaultName = vaultName;
            _code = code;
        }

        public Vault(string name)
        {
            _staticId++;
            _ownId = _staticId;
            _vaultName = name;
            int[] code = new int[10];

            Random rnd = new Random();
            for (int i = 0; i < code.Length; i++)
            {
                code[i] = (int)rnd.Next() % 100;
            }
            _code = code;
        }

        public void CheckCode()
        {
            Console.WriteLine(VaultName);
            for (int i = 0; i < _code.Length; i++)
            {
                Console.Write(_code[i] + ", ");
            }
            Console.WriteLine();
        }



        public int Id
        {
            get
            {
                return _ownId;
            }

        }
        public string VaultName
        {
            get
            {
                return _vaultName;
            }
            set
            {
                _vaultName = value;
            }
        }

        public int[] Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }

        }

    }
}
