using System;
using Taxes.Data;
using Taxes.Data.Entities;

namespace Taxes.Engine
{
    public interface ITaxWorker
    {
        void Add(Tax tax);
        float GetRate(string city, DateTime date);
        void Import(byte[] taxesData);
    }
}
