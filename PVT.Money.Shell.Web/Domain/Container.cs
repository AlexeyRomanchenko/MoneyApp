using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PVT.Money.Shell.Web.Domain
{
    public class Container : IContainer
    {
       private object obj;

       public object Create(Type type)
        {
            object obj = Activator.CreateInstance(type);
            this.obj = obj;
            return this.obj;
        }

        public void Add(Type type)
        {
//            ConstructorInfo construct = type.GetConstructor();

        }

    }

    public interface IContainer
    {
      object Create(Type type);
      void Add(Type obj);
    }
}
