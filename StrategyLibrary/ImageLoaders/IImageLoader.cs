﻿namespace StrategyLibrary.ImageLoaders;

public interface IImageLoader
{
    public byte[] GetImage(string href);
}