using System;

namespace MaterialsDomain.Api.Models
{
    public struct ShortGuid
    {
        public static readonly ShortGuid Empty = new ShortGuid(Guid.Empty); 

        private readonly Guid _guid;
        private readonly string _value;

        public ShortGuid(Guid guid)
        {
            _value = Encode(guid);
            _guid = guid;
        }

        public ShortGuid(string value)
        {
            _value = value;
            _guid = Decode(value);
        }

        public override string ToString()
        {
            return _value;
        }

        public override bool Equals(object obj)
		{
			if (obj is ShortGuid)
				return _guid.Equals(((ShortGuid)obj)._guid);
			if (obj is Guid)
				return _guid.Equals((Guid)obj);
			if (obj is string)
				return _guid.Equals(((ShortGuid)obj)._guid);
			return false;
		}

        public override int GetHashCode()
		{
			return _guid.GetHashCode();
		}

        public static ShortGuid NewGuid()
		{
			return new ShortGuid(Guid.NewGuid());
		}

        public static string Encode(string value)
		{
			Guid guid = new Guid(value);

			return Encode(guid);
		}

        public static string Encode(Guid guid)
		{
			string encoded = Convert.ToBase64String(guid.ToByteArray());
			encoded = encoded
				.Replace("/", "_")
				.Replace("+", "-");
			return encoded.Substring(0, 22);
		}

        public static Guid Decode(string value)
		{
			value = value
				.Replace("_", "/")
				.Replace("-", "+");
			byte[] buffer = Convert.FromBase64String(value + "==");
			return new Guid(buffer);
		}

        public static bool operator ==(ShortGuid x, ShortGuid y)
		{
			if ((object)x == null) return (object)y == null;
			return x._guid == y._guid;
		}

        public static bool operator !=(ShortGuid x, ShortGuid y)
		{
			return !(x == y);
		}

        public static implicit operator string(ShortGuid shortGuid)
		{
			return shortGuid._value;
		}

        public static implicit operator Guid(ShortGuid shortGuid)
		{
			return shortGuid._guid;
		}

        public static implicit operator ShortGuid(string shortGuid)
		{
			return new ShortGuid(shortGuid);
		}

        public static implicit operator ShortGuid(Guid guid)
		{
			return new ShortGuid(guid);
		}
    }
}