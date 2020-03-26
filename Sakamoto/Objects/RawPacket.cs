﻿using Sakamoto.Enums;
using osu.Shared.Serialization;
using System.IO;

namespace Sakamoto.Objects
{
	class RawPacket
	{
		public RawPacket(short type, int length, byte[] bytearray)
		{
			this.type = type;
			this.length = length;
			this.bytearray = bytearray;
		}

		public short type;
		public int length;
		public byte[] bytearray;

		public PacketType getType()
		{
			return (PacketType)type;
		}

		public string toString()
		{
			return "Type: " + (PacketType)type + " Length: " + length;
		}

		public byte[] toByteArray()
		{
			try { 
				MemoryStream ms = new MemoryStream();
				SerializationWriter writer = new SerializationWriter(ms);
				writer.Write(type);
				writer.Write(0x00); // null bytes
				writer.Write(length);
				writer.Write(bytearray);
				return ms.ToArray();
			} catch
			{
				return null;
			}
		}
	}
}
