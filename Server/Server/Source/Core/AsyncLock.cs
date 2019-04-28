using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Source.Core
{
    public class AsyncLock
    {
        private readonly AsyncSemaphore _mSemaphore;
        private readonly Task<Releaser> _mReleaser;

        public AsyncLock()
        {
            _mSemaphore = new AsyncSemaphore(1);
            _mReleaser = Task.FromResult(new Releaser(this));
        }

        public Task<Releaser> LockAsync()
        {
            var wait = _mSemaphore.WaitAsync();
            return wait.IsCompleted ?
                _mReleaser :
                wait.ContinueWith((_, state) => new Releaser((AsyncLock)state),
                    this, CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }

        public struct Releaser : IDisposable
        {
            private readonly AsyncLock _mToRelease;

            internal Releaser(AsyncLock toRelease) { _mToRelease = toRelease; }

            public void Dispose()
            {
                _mToRelease?._mSemaphore.Release();
            }
        }
    }
}
