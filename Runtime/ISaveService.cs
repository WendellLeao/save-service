namespace WendellLeao.Save
{
    public interface ISaveService
    {
        /// <summary>
        /// Triggers serialization through the assigned <see cref="ISaveDataHandler"/>.
        /// </summary>
        public void SaveData();

        /// <summary>
        /// Triggers deserialization through the assigned <see cref="ISaveDataHandler"/>.
        /// </summary>
        public void LoadData();
    }
}
