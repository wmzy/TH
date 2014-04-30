using System;
using System.Collections.Generic;

namespace TH.Services
{
    public abstract class ServiceBase: IDisposable
    {
        public IList<IDisposable> DisposableObjects { get; private set; }
        public ServiceBase()
        {
            DisposableObjects = new List<IDisposable>();
        }
         protected void AddDisposableObject(object obj)
        {
            var disposable = obj as IDisposable;
            if (null != disposable)
            {
                DisposableObjects.Add(disposable);
            }
        }

         public void Dispose()
         {
             foreach (var obj in DisposableObjects)
             {
                 if (null != obj)
                 {
                     obj.Dispose();
                 }
             }
         }
    }
}