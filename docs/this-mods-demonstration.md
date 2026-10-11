# This mod's demonstration

Part of [KSP Diag - Landed Vessel](../README.md): what the mod reads, and what it cannot tell on its own.

The mod measures the distance from your craft to the centre of the body, in millimetres, and records
two values:

- **on rails**, while the game is still holding the craft at the position it was given, before
  physics has run on it;
- **settled**, once the craft has come to rest on the ground (every frame).

Both are the same measurement, taken between the origin of the root part of the craft — the very
point KSP keeps for the craft while it is on rails — and the centre of the body, in double
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

The difference between the two — **Moved** in [the window](the-window.md) — is how far physics took
the craft from the position the game placed it at. Its sign says which way the craft went, and how much
the figure is worth.

**Negative** — the craft was placed above the surface it ends up resting on, and dropped onto it. That
is a clean measurement: the figure is the gap it fell through.

**Positive** — the craft was placed below that surface, so it started off inside it and the physics
pushed it back out. The figure is then spoiled: it measures how hard it was shoved, not how deep it
started.

Two things the difference does not tell you.

**A craft the game moved itself reads like one that settled.** When it brings a landed craft into the
world, the game sometimes puts it back onto the ground before its physics starts: stock KSP does it for a
craft made of a single part and for a craft in the *prelaunch* situation, and some mods, such as
[Real Solar System](https://github.com/KSP-RO/RealSolarSystem), do it for every landed craft. When the
craft is placed more than 10 cm off the ground, inside it or above it, it is moved onto it in one
block, and the difference then shows that move, not a craft coming to rest. The readings cannot tell
the two apart; `KSP.log` can: every such move leaves a line `ground contact! - error. Moving Vessel up
X.XXXm` (or `down`) naming the craft, right before `Unpacking`. That is why
[Taking a reading](../README.md#taking-a-reading) keeps to readings without that line, and why, where
it cannot be avoided, the lines it moved are to be marked as such.

**A jump or a tip-over does not show in the numbers.** There is one height per reading, and whether the
craft jumped to get there is something you see on screen, not in the numbers: a jump ends at a height
like any other. A craft that tipped over is worse: its root part now lies on its side, and **Settled**
reads the height of a craft lying down, not one that settled. Note what you saw next to each line.

Another instrument,
[KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight), measures **the
ground** itself — the height of the surface your craft is touching, against the height the game
computes for that same spot — and does not care what the craft does. You do not need it to follow
these readings.

