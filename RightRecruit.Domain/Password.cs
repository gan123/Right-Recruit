namespace RightRecruit.Domain
{
    public class Password
    {
        public byte[] Value { get; set; }

        public Password(byte[] value)
        {
            Value = value;
        }
    }
}