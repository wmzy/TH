using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TH.WebUI.Controllers
{
    public class THController
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

        protected void Dispose(bool disposing)
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
        }
    }
}