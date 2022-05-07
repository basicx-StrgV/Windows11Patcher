//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/                 //
//--------------------------------------------------//
using Windows11Patcher.Actions;
using Windows11Patcher.HelperClasses;

namespace Windows11Patcher.Runtime
{
    public class RuntimeBuilder
    {
        public IRuntime Build(string[] args)
        {
            return new DefaultRuntime()
            {
                Actions = GetAllPatchActions()
            };
        }

        /// <summary>
        /// Gets all patch actions for the patch runtime.
        /// </summary>
        /// <param name="autoRun">
        /// Sets if the actions should autorun or not. (DEFAULT = false)
        /// </param>
        /// <returns>
        /// A array of all <see cref="Windows11Patcher.Actions.IAction"/>'s.
        /// </returns>
        private IAction[] GetAllPatchActions(bool autoRun = false)
        {
            IAction[] actions = new IAction[0];
            /*actions = ArrayManager.AddEntry(
                actions,
                new ContextMenuPatchAction()
                {
                    AutoRun = autoRun
                });*/

            actions = ArrayManager.AddEntry(
                actions,
                new RoundedCornersPatchAction()
                {
                    AutoRun = autoRun
                });

            return actions;
        }
    }
}
