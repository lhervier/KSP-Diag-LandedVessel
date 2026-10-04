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
runway, which is not the ground. All four fill the same window, and all four come with the craft and
the save they were written for.

**Loading the same save.** A lone capsule — no anchor, no wheels, no landing legs — set down on bare
flat ground, away from the runway and the launchpad, which are structures rather than ground. Let it
settle, save once, then load that same save five or six times, pressing *Record* each time the live
line has stopped moving.

**→ Full chapter: [The protocol: loading the same save](docs/the-protocol-loading.md)**

**Coming back to a craft you left.** This one loads nothing at all. A craft stays parked on the same
kind of ground while you drive a rover away from it, past 2500 m, where the game unloads it — then
back to within 200 m, where its physics starts again. Five records per round trip, and as many round
trips as you like, without ever changing scene.

**→ Full chapter: [The protocol: coming back to a craft you left](docs/the-protocol-approach.md)**

**Switching to a craft far away.** Two craft landed 1.97 km apart. Load the save while flying one,
press *Record*, switch to the other with the game's own key, and press *Record* again. Then load the
same save again, six times in all.

**→ Full chapter: [The protocol: switching to a craft far away](docs/the-protocol-switching.md)**

**The runway and the grass beside it.** Where the first protocol tells you not to go. Two identical
craft, one on the runway and one on the grass beside it. Load the save while flying the one on the
grass, press *Record*, switch to the other with the game's own key, and press *Record* again. Then load
the same save again, six times in all. A second save does the same on the Mun, beside a runway placed
by Kerbal Konstructs.

**→ Full chapter: [The protocol: the runway and the grass beside it](docs/the-protocol-runway.md)**

## The measurements

Four series, one per protocol, all taken in the same install: Harmony, ModuleManager and
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) — what most players run —
with this mod added. The first also goes to the Moon and to Earth, in that install with
[Real Solar System](https://github.com/KSP-RO/RealSolarSystem) added, and the fourth to the Mun, with
[Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs) added.

In all four, **On rails** — the height the game hands the craft back at — barely moves: two
thousandths of a millimetre at most from one loading to the next in the first series, six thousandths
across a round trip in the second, two thousandths across six loadings in the third, one thousandth in
the fourth. So the craft itself is put back where it was.
What it then comes to rest on is never quite where it was.

**Loading the same save** ([the protocol in full](docs/the-protocol-loading.md)). The same save
loaded six times on Kerbin, on the Mun, on Minmus and on Gilly, with a lone capsule, then the whole
campaign again with a two-part craft, which also goes to the Moon and to Earth of Real Solar System,
much larger. Every series is played by a script, through KSP-MCPServer. The height the craft comes to
rest at is never the same twice: lowest to highest, with one part then two, 73.7 and 43.7 mm on Kerbin,
5.6 and 18.2 mm on the Mun, 4.6 and 7.3 mm on Minmus, 1.4 and 2.3 mm on Gilly, then 49.2 mm on the Moon
and 292.4 mm on Earth. Real Solar System ships a workaround of its own, which moves a craft back onto
the ground when it comes back more than 10 cm off; below that, the craft still jumps, and on the Moon
it tipped over four times with the workaround running.

**→ Full chapter: [The measurements: loading the same save](docs/the-measurements-loading.md)**

**Coming back to a craft you left** ([the protocol in full](docs/the-protocol-approach.md)). Six
round trips in a row on Kerbin, in a single flight, with nothing loaded at any point: the craft comes
to rest 7.5 to 19.2 mm from the height it was handed back at, upwards as often as downwards, and a
different amount every time.

**→ Full chapter: [The measurements: coming back to a craft you left](docs/the-measurements-approach.md)**

**Switching to a craft far away** ([the protocol in full](docs/the-protocol-switching.md)). Six
rounds on Kerbin, in the same kind of install as the approach series: the capsule is handed back at
the same height every time, within two thousandths of a millimetre, and comes to rest after the switch
at a different height every time: 104.5 mm from the lowest to the highest, upwards as well as
downwards.

**→ Full chapter: [The measurements: switching to a craft far away](docs/the-measurements-switching.md)**

**The runway and the grass beside it** ([the protocol in full](docs/the-protocol-runway.md)). Six
loadings on Kerbin, two identical craft 152 m apart. Both are handed back at the same height every
time, within a thousandth of a millimetre. Both come to rest somewhere else every time: within 88.3 mm
on the grass, within 130.3 mm on the runway. And not together: the step between them, which is the step
between the grass and the runway, spreads over 81.7 mm. The same on the Mun, beside a runway placed by
[Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs): within 24.1 mm on the ground,
33.5 mm on the runway, 42.9 mm for the step. Whether the game or a mod places it, a structure behaves
the same.

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
