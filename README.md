# KSP Diag - Landed Vessel

**⚠️ Work in progress.** This is an active investigation, not a finished mod. The code and the pages of this repository can still change.

**How this was made.** Written with Claude, Anthropic's AI assistant, and reviewed line by line by a
human — me. I am saying so before anything else, because contributions made with an AI deserve a closer
look than others, and because some people would rather stop reading here. This mod measures and fixes
nothing, so what there is to check is the reading itself: the source is public, and the few lines that
take it are quoted in [This mod's demonstration](docs/this-mods-demonstration.md).

A measuring instrument for KSP 1.12. It measures where a landed craft is — the craft you are flying, or
your target — as its distance to the centre of the body, in millimetres. It takes that reading at two
moments: once when the game loads the craft (a save loaded, a craft you come back to or switch to), while
the craft is still on rails, before physics has run on it; then live, for as long as the craft stays in
the scene.

## This mod's demonstration

The mod measures the distance from your craft to the centre of the body twice: **on rails**, where the
game hands it back, and **settled**, once it has come to rest.

**→ Full chapter: [This mod's demonstration](docs/this-mods-demonstration.md)**

## The window

In flight, a window shows one line per reading, in millimetres: **On rails**, **Settled**, and
**Moved**, the difference between the two. It follows the craft you are flying, or your target; the
bottom line runs live until *Record* freezes it.

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
