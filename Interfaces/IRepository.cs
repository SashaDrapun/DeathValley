﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeathValley
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAll(); 
        T GetById(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id);
        void Save();
    }
}
