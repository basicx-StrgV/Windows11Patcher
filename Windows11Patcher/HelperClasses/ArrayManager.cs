namespace Windows11Patcher.HelperClasses
{
    public static class ArrayManager
    {
        /// <summary>
        /// Adds a new entry to the end of a array.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the given array.
        /// </typeparam>
        /// <param name="array">
        /// The array to add the entry to.
        /// </param>
        /// <param name="value">
        /// The value for the new entry.
        /// </param>
        /// <returns>
        /// the array with a new entry added.
        /// </returns>
        public static T[] AddEntry<T>(T[] array, T value)
        {
            T[] newArray = CopyTo(array, 1);
            newArray[^1] = value;
            return newArray;
        }

        /// <summary>
        /// Copys one array to a new one.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array.
        /// </typeparam>
        /// <param name="array">
        /// The array to copy.
        /// </param>
        /// <param name="addPositions">
        /// Count of extra positions that should be added to the end of the new array.
        /// </param>
        /// <returns>
        /// A new array with all data copied from the given array.
        /// </returns>
        public static T[] CopyTo<T>(T[] array, int addPositions = 0)
        {
            T[] newArry = new T[array.Length + addPositions];
            for (int i = 0; i < array.Length; i++)
            {
                newArry[i] = array[i];
            }
            return newArry;
        }
    }
}
