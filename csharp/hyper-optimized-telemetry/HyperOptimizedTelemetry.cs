using System;
using System.Diagnostics;
using System.Linq;
using Xunit.Sdk;

public static class TelemetryBuffer
{

    public static byte[] ToBuffer(long reading)
    {

        var bytes = BitConverter.GetBytes(reading);
        var buffer = new byte[9];

        (var prefix, var elements) = reading switch
        {
            (< int.MinValue or > uint.MaxValue) => (248, 8),
            (> int.MaxValue) => (4, 4),
            (< short.MinValue or > ushort.MaxValue) => (252, 4),
            (<= short.MaxValue) => (254, 2),
            _ => (2, 2)
        };

        buffer[0] = (byte)prefix;

        Buffer.BlockCopy(bytes, 0, buffer, 1, elements);

        return buffer;

    }

    public static long FromBuffer(byte[] buffer) => buffer[0] switch
    {
        248 => BitConverter.ToInt64(buffer, 1),
        004 => BitConverter.ToUInt32(buffer, 1),
        252 => BitConverter.ToInt32(buffer, 1),
        002 => BitConverter.ToUInt16(buffer, 1),
        254 => BitConverter.ToInt16(buffer, 1),
        _ => 0,

    };





}

