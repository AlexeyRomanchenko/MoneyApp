using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVT.Money.Shell.Web.Controllers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DocumentationAttribute : Attribute
    {
        public string v;

        public DocumentationAttribute(string v)
        {
            this.v = v;
        }
    }



}
