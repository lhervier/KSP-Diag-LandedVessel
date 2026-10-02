# This mod's demonstration

Part of [KSP Diag - Landed Vessel](../README.md): what the mod reads, why those two numbers are enough, and what they cannot tell on their own.

You cannot look at the ground and see this: the surface you walk on and the surface you see are one
and the same, so the picture shifts along with it. What you can see is what rests *on* the ground. So
the mod measures the distance from your craft to the centre of the body, in millimetres, and records
two values:

- **on rails**, while the game is still holding the craft at the position it was given, before
  physics has run on it — at the opening of a scene, the position the save gives back;
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

Reload the same save several times, then read the two columns against each other. The first one tells
you whether KSP puts the craft back where it was; the second one tells you where it actually came to
rest. As long as neither of them varies from one loading to the next, the round trip is exact and
nothing about the craft itself has changed. One of them does vary, though — spoiler: the second one.

## What this instrument shows, and what it does not

Both readings are of the **craft**: a craft set down on the ground does not come back to rest where
the save left it, one loading to the next. That is what the instrument sees, and that is where it
stops. It does not, on its own, name what moved. A ground rebuilt a little higher or a little lower on
every loading accounts for the figures — but so would a perfectly steady ground with the craft set
down beside it, off by a rounding error shared by the placement and by the **On rails** reading, where
it would cancel out. Both fill the same table.

A second instrument,
[KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight), tells the
two apart: it measures **the ground** itself — the height of the surface your craft is touching,
against the height the game computes for that same spot — with no craft in the picture at all. You do
not need it to follow these readings.

