using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModel.connnection.reponsitory
{
    public interface IReponsitory<T> where T : class
    {
        IEnumerable<T> getAll();
        T getById(object id);
        void insert(T obj);
        void update(T obj);
        void delete(object id);
        void save();
    }
}
