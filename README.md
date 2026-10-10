# KSP Diag - Landed Vessel

**⚠️ Work in progress.** This is an active investigation, not a finished mod. The code and the pages of this repository can still change.

**How this was made.** Written with Claude, Anthropic's AI assistant, and reviewed line by line by a
human — me. I am saying so before anything else, because contributions made with an AI deserve a closer
look than others, and because some people would rather stop reading here. This mod measures and fixes
nothing, so what there is to check is the reading itself: the source is public, and the few lines that
take it are quoted in [This mod's demonstration](docs/this-mods-demonstration.md).

A measuring instrument for KSP 1.12. Whenever the game sets a landed craft down — when a save is loaded,
when you come back to a craft you left parked, when you switch to a craft far away — it reads the height
the game hands the craft back at, and the height the craft actually comes to rest at. It lets you check,
on your own install, whether a landed craft comes back to rest where it was left.

Why that matters, and what was found with it, is told by
[Terrain Precision Fix](https://github.com/lhervier/KSP-TerrainPrecisionFix#why-the-moving-ground-matters).

## This mod's demonstration

You cannot look at the ground and see whether it moved: the surface you walk on and the surface you see
are one and the same, so the picture shifts along with it. What you can see is what rests *on* the
ground. So the mod measures the distance from the root part of your craft to the centre of the body, in
millimetres and in double precision from end to end, and records it twice: **on rails**, while the game
is still holding the craft at the position it was given, before physics has run on it — at the opening
of a scene, the position the save gives back — and **settled**, once the craft has come to rest. Reload
the same save several times, then read the two columns against each other. As long as neither of them
varies from one loading to the next, the round trip is exact and nothing about the craft itself has
changed.

Both readings are of the **craft**, and that is where the instrument stops: it does not, on its own,
name what moved. A ground rebuilt a little higher or a little lower at every loading would account for
a varying **Settled**, but so would a perfectly steady ground with the craft set down beside it. A second
instrument, [KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight), tells the
two apart: it measures the ground itself, with no craft in the picture at all.

**→ Full chapter: [This mod's demonstration](docs/this-mods-demonstration.md)**

## The window

In flight, a window shows one line per reading, in millimetres: **On rails**, **Settled**, and
**Moved**, the difference between the two; the bottom line runs live until *Record* freezes it. It
follows the craft you are flying, or your target — which is how a parked craft can be followed while you
drive away from it and back. **Moved** should be zero, and its sign tells you what it is worth: a craft
that fell onto the surface gives a clean reading, one pushed back out of it does not. It does not show
when the game itself put the craft back onto the ground, nor a jump or a tip-over.

**→ Full chapter: [The window](docs/the-window.md)**

## Taking a reading

Set a craft down on bare ground and save once. Load that save, watch the live line until it stops
moving, and press *Record*. Load the same save again, and record again. Each line is one loading: it is
the series that is worth reading, not a line. A few rules keep the reading about the ground the craft
rests on, and nothing else:

- **Two parts at least, no landing legs, no wheels.** KSP sets a craft made of a single part back onto
  the ground itself at every loading, and a suspension moves the craft while it compresses. A capsule on
  a small flat fuel tank is enough.
- **A spot where it does not slide.** The ground need not be flat, but if **Settled** keeps changing
  instead of stopping, the craft is sliding: turn SAS on before saving, or pick another spot.
- **Bare ground, not a runway or a launch pad.** They are structures the game places its own way: a
  reading taken there is about the structure, not the ground.
- **Never save during the series.** Every loading must start from the same save.
- **Do not touch the throttle.** Open it, even by a few percent, even on a craft with no engine, and the
  game no longer holds the craft still.
- **Keep to loadings without a `Moving Vessel` line** naming your craft in `KSP.log`: that line means
  the game moved the craft itself — [The window](docs/the-window.md) says why it matters.

A craft you come back to, or switch to, is read the same way: record once its physics has taken it
over, three to five seconds later.

## Measured campaigns

This instrument reads the landed craft in the campaigns of
[Terrain Precision Fix](https://github.com/lhervier/KSP-TerrainPrecisionFix), each played without that
mod and with it, with its protocol, its saves, its scripts and its logs:
loading the same save, [on bare ground](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-loading/the-ground.md#the-craft-over-six-loads)
and [on a runway and the ground beside it](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-loading/the-statics.md#the-craft-on-a-runway),
[coming back to a craft left parked](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-approach.md)
and [switching to a craft far away](https://github.com/lhervier/KSP-TerrainPrecisionFix/blob/main/docs/checking-the-culprit-switching.md).
The figures read with it are on those pages.

## Get it

Either way you end up with the same `GameData/KSPDiagLandedVessel/` folder.

**Download it** — from the assets of the
[latest release](https://github.com/lhervier/KSP-Diag-LandedVessel/releases/latest).

**Or compile it** — clone this repository, set `KSPDIR` to your KSP install folder and run
`build.bat`. It needs the .NET SDK and
[KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer) installed in that KSP, takes a few seconds,
reads the KSP assemblies straight from your install, and puts the DLL in
`GameData/KSPDiagLandedVessel/` inside the repository. It does not install anything.
KSP-MCPServer is only needed to compile: it provides the attribute that marks what this mod offers to
it, and this mod runs the same without it. Worth doing if you would rather not run a binary you have no source for
while reporting a measurement.

## Install

Drop `GameData/KSPDiagLandedVessel` into the `GameData` of KSP, so that you end up with
`GameData/KSPDiagLandedVessel/KSPDiagLandedVessel.dll`. It runs on a stock install.

## License

MIT
