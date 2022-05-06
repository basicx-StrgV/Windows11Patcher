//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/                 //
//--------------------------------------------------//
using Windows11Patcher.Actions;

namespace Windows11Patcher.Runtime
{
    public class DefaultRuntime : IRuntime
    {
        /// <summary>
        /// Gets or sets the action for the runtime process.
        /// </summary>
        public IAction[] Actions { get; set; }

        public void Run()
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                Actions[i].Run();
            }
        }
    }
}
