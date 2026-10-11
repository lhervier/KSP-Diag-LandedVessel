# This mod's demonstration

Part of [KSP Diag - Landed Vessel](../README.md): what the mod reads, and what it cannot tell on its own.

The mod measures the distance from your craft to the centre of the body, in millimetres, and records
two values:

- **on rails**, while the game is still holding the craft at the position it was given, before
  physics has run on it;
- **settled**, once the craft has come to rest on the ground (every frame).

Both are the same measurement, taken between the origin of the root part of the craft — the very
point KSP writes to the save and hands back on loading — and the centre of the body, in double
precision from end to end:

```csharp
private static double DistanceToCentreMm(Vessel vessel)
{
    // Vector3d on both sides, deliberately: reading a few millimetres out of six hundred
    // kilometres leaves no room for anything short of double precision.
    Vector3d toCentre = (Vector3d)vessel.vesselTransform.position - vessel.mainBody.position;
    return toCentre.magnitude * 1000.0;
}
```

The first one shows where the game places the craft when it brings it into the world — not only when a
save is loaded, but also when you switch to a craft, or come back within range of one you left parked.
The second one shows where the craft settles once physics is running on it.

## What this instrument shows, and what it does not

Both readings are of the **craft**, and only of the craft: the origin of its root part, against the
centre of the body. The instrument never looks at the ground — neither the colliders the craft rests
on, nor the height the game computes for that spot. **Settled** tells where the craft came to rest,
not how high the ground under it is.

Another instrument,
[KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight), measures **the
ground** itself — the height of the surface your craft is touching, against the height the game
computes for that same spot — and does not care what the craft does. You do not need it to follow
these readings.

