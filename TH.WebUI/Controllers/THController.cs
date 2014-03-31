using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TH.Extensions;

namespace TH.WebUI.Controllers
{
    [ExceptionPolicy("defaultPolicy")]
    public class THController : ExtendedController
    {
        public IList<IDisposable> DisposableObjects { get; private set; }
        public THController()
        {
            this.DisposableObjects = new List<IDisposable>();
        }

        protected void AddDisposableObject(object obj)
        {
            IDisposable disposable = obj as IDisposable;
            if (null != disposable)
            {
                this.DisposableObjects.Add(disposable);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (IDisposable obj in this.DisposableObjects)
                {
                    if (null != obj)
                    {
                        obj.Dispose();
                    }
                }
            }
            base.Dispose(disposing);
        }
    }
}