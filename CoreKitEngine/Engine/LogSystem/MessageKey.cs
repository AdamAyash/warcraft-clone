namespace CoreKitEngine.Engine.LogSystem
{
    public class MessageKey
    {
        public string Key { get; private set; }
        public string Value { get; set; }

        public MessageKey(string strKey, object oValue)
        {
            this.Key = strKey;
            this.Value = oValue.ToString();
        }
    }
}
