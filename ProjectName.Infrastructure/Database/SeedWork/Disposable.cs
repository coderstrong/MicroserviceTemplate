﻿using System;

namespace ProjectName.Infrastructure.Database
{
    public class Disposable : IDisposable
    {
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        ~Disposable()
        {
            Dispose(false);
        }
    }
}
