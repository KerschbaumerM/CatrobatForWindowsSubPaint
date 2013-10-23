﻿using System;
using Windows.UI.Core;
using Catrobat.IDE.Core.Services;

namespace Catrobat.IDE.Store.Services
{
    public class DispatcherServicePhone : IDispatcherService
    {
        private readonly CoreDispatcher _dispatcher;

        public DispatcherServicePhone(CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void RunOnMainThread(Action action, DispatcherPriority priority)
        {
            var dispatcherPriority = CoreDispatcherPriority.Normal;

            switch (priority)
            {
                case DispatcherPriority.Low:
                    dispatcherPriority = CoreDispatcherPriority.Low;
                    break;
                case DispatcherPriority.Normal:
                    dispatcherPriority = CoreDispatcherPriority.Normal;
                    break;
                case DispatcherPriority.High:
                    dispatcherPriority = CoreDispatcherPriority.High;
                    break;
                case DispatcherPriority.Idle:
                    dispatcherPriority = CoreDispatcherPriority.Idle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("priority");
            }

            _dispatcher.RunAsync(dispatcherPriority, () => action());
        }
    }
}
