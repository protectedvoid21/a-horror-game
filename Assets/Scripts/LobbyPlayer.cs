using System;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public struct LobbyPlayer : INetworkSerializable, IEquatable<LobbyPlayer> {
    public ulong id;
    public FixedString32Bytes name;

    public LobbyPlayer(ulong id, string name) {
        this.id = id;
        this.name = name;
    }
    
    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter {
        serializer.SerializeValue(ref id);
        serializer.SerializeValue(ref name);
    }

    public bool Equals(LobbyPlayer player) {
        return player.id == id && player.name == name;
    }
}
