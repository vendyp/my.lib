﻿namespace MyLib.Abstractions.Encryption;

public interface ISha512
{
    string Hash(string data);
}