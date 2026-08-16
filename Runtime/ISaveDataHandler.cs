namespace WendellLeao.Save
{
    public interface ISaveDataHandler
    {
        /// <summary>
        /// Serializes the game's save data to disk.
        /// </summary>
        public void SaveData();

        /// <summary>
        /// Deserializes the game's save data from disk.
        /// </summary>
        public void LoadData();
    }
}
