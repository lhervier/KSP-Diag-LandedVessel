# KSP Diag - Landed Vessel

**⚠️ Work in progress.** This is an active investigation, not a finished mod. The figures, the code and the conclusions on this page can still change, and several questions are still open.

**How this was made.** Written with Claude, Anthropic's AI assistant, and reviewed line by line by a
human — me. I am saying so before anything else, because contributions made with an AI deserve a closer
look than others, and because some people would rather stop reading here. This mod measures and fixes
nothing, so what there is to check is the reading itself: the source is public, and the protocol it
comes with runs on a stock install, on your own craft, against the figures given here.

A measuring instrument for KSP 1.12, and the first of a small family of them. It lets you check, on
your own install, a claim about the ground your craft is parked on:

> **The ground KSP builds under you is never built at the same height twice.** Load the same save five
> times, and the surface your craft is standing on comes back a little higher or a little lower each
> time — a few centimetres apart on Kerbin, less on smaller worlds, and up to seventy on Earth in
> Real Solar System.

## Why it matters

Every time you load, it is a coin toss between two outcomes.

**The ground comes back lower than it was when you saved.** Your craft is now hovering a couple of
centimetres above it, so it drops those two centimetres. You never notice, and nothing breaks.

**The ground comes back higher than it was when you saved.** Your craft is now *inside* the ground —
and the physics engine will not leave two solid things overlapping. It pushes them apart, hard, in
the only direction available: up. Your craft gets launched.

![A craft jumping on its own the moment a save is reloaded](https://raw.githubusercontent.com/lhervier/KSP-TerrainPrecisionFix/master/imgs/Booing-scaled.gif)

*KSP 1.12 with [KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) as the only
mod installed. A pod on an empty fuel tank, parked in the grass at the KSC, saved, then reloaded from the
pause menu, several times if needed — nothing touched in between.*

That second case is the symptom everybody already knows. The lander that twitches, hops or flips the
moment the scene finishes loading. The base that sat perfectly flush yesterday and is buried up to
the hatches today. The big base that tears itself apart the very first time you load it, and never
again afterwards. A craft with many parts spread over a wide area gives the coin toss more chances
to land the wrong way up.

**Loading is not the only time the coin is tossed.** A landed craft you fly towards is loaded long
before you reach it, but held still at the position it was left at; its physics only starts once you
are within 200 m. The ground under it was not built when that position was recorded, so the same toss
happens there. From 200 m away you see much less of it — and it does just as much damage.

Both can be measured with this mod, and each has its own protocol: loading the same save over and
over, which is the easiest to repeat, and driving away from a parked craft and coming back, which
never loads anything at all.

### Disclaimer: it is not the only cause

The ground moving is one cause among several, and this page does not claim it is the only one. Plenty
of other things move a craft when a scene opens. Two well-known examples, among others:

- **suspensions.** Landing legs and wheels come back fully extended, because that is the only state
  KSP can restore them to. They then compress under the weight of the craft, and the craft moves
  while they do.
- **a craft bent to fit the ground.** While you play, physics twists the joints between parts so the
  craft settles onto the shape of the ground beneath it. That twisting is not saved. On loading, the
  craft comes back in its original, unbent shape — and if the ground is not flat, part of it really
  *is* underground, with no measurement error involved.

Both of those are avoidable, and that is exactly why [the first protocol below](docs/the-protocol-loading.md) uses a
single capsule with no legs and no wheels, on flat ground: it takes them out of the picture, along with anything else that
needs a suspension, several parts, or a slope to happen.

## This mod's demonstration

You cannot look at the ground and see this: the surface you walk on and the surface you see are one and
the same, so the picture shifts along with it. What you can see is what rests *on* the ground. So the
mod measures the distance from the root part of your craft to the centre of the body, in millimetres and
in double precision from end to end, and records it twice: **on rails**, while the game is still
holding the craft at the position it was given, before physics has run on it — at the opening of a
scene, the position the save gives back — and **settled**, once the craft has come to rest. Reload the same save several times, then read the two columns against each
other. As long as neither of them varies from one loading to the next, the round trip is exact and
nothing about the craft itself has changed. One of them does vary.

Both readings are of the **craft**, and that is where the instrument stops: it does not, on its own,
name what moved. A ground rebuilt a little higher or a little lower at every loading accounts for the
figures, but so would a perfectly steady ground with the craft set down beside it. A second instrument,
[KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight), tells the two
apart: it measures the ground itself, with no craft in the picture at all.

**→ Full chapter: [This mod's demonstration](docs/this-mods-demonstration.md)**

## The window

In flight, a window shows one line per reading, in millimetres: **On rails**, **Settled**, and
**Moved**, the difference between the two; the bottom line runs live until *Record* freezes it. It
follows the craft you are flying, or your target — which is how the second protocol below follows a
parked craft. **Moved** should be zero, and its sign tells you what it is worth: a craft that fell onto
the surface gives a clean reading, one pushed back out of it does not. It does not show when the game
itself put the craft back onto the ground, nor a jump or a tip-over.

**→ Full chapter: [The window](docs/the-window.md)**

## The protocol

Three protocols, one for each way the game can set a craft down on the ground, and a fourth for the
runway, which is not the ground. All four fill the same window, and come with their craft and save.

**Loading the same save.** Set a capsule on a small tank down on bare, flat ground, save once, then load that
same save six times, recording after each loading.

**→ Full chapter: [The protocol: loading the same save](docs/the-protocol-loading.md)**

**Coming back to a craft you left.** In one single flight, drive a rover away from a parked craft
until the game unloads it, then back until its physics starts again.

**→ Full chapter: [The protocol: coming back to a craft you left](docs/the-protocol-approach.md)**

**Switching to a craft far away.** Load a save holding two craft 1.97 km apart, record, switch to the
other with the game's own key, and record again; six loadings.

**→ Full chapter: [The protocol: switching to a craft far away](docs/the-protocol-switching.md)**

**The runway and the grass beside it.** The same with two identical craft, one on the runway and one
on the grass beside it, on Kerbin, then on the Mun beside a runway placed by Kerbal Konstructs.

**→ Full chapter: [The protocol: the runway and the grass beside it](docs/the-protocol-runway.md)**

## The measurements

Taken with Harmony, ModuleManager and [KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes)
— what most players run — and this mod, every series played by the script of its protocol through
[KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer). Each page gives its install in full.

In all four, **On rails** — the height the game hands the craft back at — comes back to within a
thousandth or two of a millimetre: the craft itself is put back where it was. What it comes to rest on
is not.

**Loading the same save** ([the protocol in full](docs/the-protocol-loading.md)). On the four stock
worlds, then on the Moon and Earth of Real Solar System. The height the craft comes to rest at is never
the same twice: up to 43.7 mm apart on Kerbin, 292.4 mm on Earth.

**→ Full chapter: [The measurements: loading the same save](docs/the-measurements-loading.md)**

**Coming back to a craft you left** ([the protocol in full](docs/the-protocol-approach.md)). Six
round trips on Kerbin, nothing loaded: the craft comes to rest 6.6 to 37.2 mm from the height it was
handed back at, a different amount every time.

**→ Full chapter: [The measurements: coming back to a craft you left](docs/the-measurements-approach.md)**

**Switching to a craft far away** ([the protocol in full](docs/the-protocol-switching.md)). Six
rounds on Kerbin: after the switch, the capsule comes to rest at a different height every time,
112.0 mm from the lowest to the highest.

**→ Full chapter: [The measurements: switching to a craft far away](docs/the-measurements-switching.md)**

**The runway and the grass beside it** ([the protocol in full](docs/the-protocol-runway.md)). Both
craft come to rest somewhere else at every loading, and not together: the step between the grass and
the runway spreads over 38.5 mm on Kerbin. A runway placed by Kerbal Konstructs on the Mun does the
same.

**→ Full chapter: [The measurements: the runway and the grass beside it](docs/the-measurements-runway.md)**

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
