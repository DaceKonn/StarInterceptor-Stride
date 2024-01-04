using Stride.Core.Diagnostics;
using Stride.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Profiling;
using Stride.Audio;
using Stride.Core.Serialization.Contents;
using Stride.Engine.Processors;
using Stride.Games;
using Stride.Graphics;
using Stride.Rendering.Sprites;
using Stride.Rendering;
using Stride.Streaming;

namespace StarInterceptor.Core.Processors
{
    public abstract class SimpleEntityProcessor<T> : EntityProcessor<T> where T : EntityComponent
    {
        private Logger logger;

        [DataMemberIgnore]
        protected Logger Log
        {
            get
            {
                if (logger != null)
                {
                    return logger;
                }

                var className = GetType().FullName;
                logger = GlobalLogger.GetLogger(className);
                return logger;
            }
        }

        protected DebugTextSystem DebugText { get; private set; }

        internal void Initialize(IServiceRegistry registry)
        {
            DebugText = Services.GetSafeServiceAs<DebugTextSystem>();
        }
    }
}
