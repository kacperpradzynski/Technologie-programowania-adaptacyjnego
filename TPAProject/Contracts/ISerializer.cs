﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISerializer
    {
        void Serialize<T>(T _object);
        T Deserialize<T>();
        string GetPath();
        bool IsDeserializationPossible();

    }
}