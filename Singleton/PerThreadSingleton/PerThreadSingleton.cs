﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerThreadSingleton
{
    public sealed class PerThreadSingleton
    {
        private static ThreadLocal<PerThreadSingleton> threadInstance
            = new ThreadLocal<PerThreadSingleton>(() => new PerThreadSingleton());

        public int Id { get; set; }

        private PerThreadSingleton()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }

        public static PerThreadSingleton Instance => threadInstance.Value;
    }
}
