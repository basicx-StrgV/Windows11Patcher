//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/                 //
//--------------------------------------------------//
namespace Windows11Patcher.Actions
{
    public interface IAction
    {
        /// <summary>
        /// Gets or sets if running this action needs to be accepted by the user.
        /// </summary>
        public bool AutoRun { get; set; }

        /// <summary>
        /// Run the action.
        /// </summary>
        public void Run();
    }
}
