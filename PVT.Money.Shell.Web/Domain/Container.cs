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
            ICollection<ConstructorInfo> ctors = type.GetConstructors();
            List<ConstructorInfo> ctorList = ctors.ToList();
            ConstructorInfo res = ctorList[0];

            foreach (ConstructorInfo Info in ctors)
            {
                if (Info.GetParameters().Length <= res.GetParameters().Length)
                    res = Info;
            }

            MethodInfo method = typeof(Container).GetMethod("Create");
            List<object> parameters = new List<object>();
            ParameterInfo[] paramInfo = res.GetParameters();

            foreach (ParameterInfo Info in paramInfo)
            {
                Type t = Info.ParameterType;
                MethodInfo genericMethod = method.MakeGenericMethod(type);
                parameters.Add(genericMethod.Invoke(this, null));
            }

            object obj = Activator.CreateInstance(type);
            this.obj = obj;
            return this.obj;
        }

        List<object> list = new List<object>();

        public void Add(Type type)
        {
                list.Add(type);
        } 
    }

    public interface IContainer
    {
      object Create(Type type);
      void Add(Type obj);
    }
}
