using Stride.Core;
using Stride.Engine.Design;
using Stride.Engine.Processors;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Core
{
    [DataContract("SimpleEntityComponent", Inherited = true)]
    //[DefaultEntityComponentProcessor(typeof(ScriptProcessor), ExecutionMode = ExecutionMode.Runtime)]
    [Display(Expand = ExpandRule.Once)]
    //[AllowMultipleComponents]
    [ComponentOrder(1000)]
    //[ComponentCategory("Scripts")]
    public class SimpleEntityComponent : EntityComponent
    {
    }
}
