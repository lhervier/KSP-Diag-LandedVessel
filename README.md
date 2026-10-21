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

Set a craft down and let it come to rest. Then have the game put it on rails and bring it back,
whichever way you like — for instance, load a save, switch to a craft far away and back, or drive away
from it with it as your target, past 2250 m, and come back. Once its physics has taken it over, watch
the live line until it stops moving, and press *Record*.

Some situations change what a reading says, and are worth keeping in mind when you read it. For
instance:

- **A craft made of a single part.** KSP sets it back onto the ground itself each time it brings it
  into the world.
- **Landing legs or wheels.** A suspension moves the craft while it compresses, and **Settled** takes
  that in.
- **A craft that slides.** **Settled** keeps changing instead of stopping. SAS, or another spot, holds
  it still.
- **A runway or a launch pad.** They are structures the game places its own way: the craft rests on the
  structure, not on the ground.
- **An open throttle**, even by a few percent, even on a craft with no engine: the game no longer holds
  the craft still.
- **A `Moving Vessel` line** naming your craft in `KSP.log`: the game moved the craft itself —
  [This mod's demonstration](docs/this-mods-demonstration.md#what-this-instrument-shows-and-what-it-does-not)
  says what that does to the reading.

## Driving it by script

With [KSP-Util-MCPServer](https://github.com/lhervier/KSP-Util-MCPServer) installed next to it, this mod offers
its window to a program, as tools of that server: a script presses its buttons and reads what it shows,
as a player would. Without the server, this mod runs the same.

| tool | what it does |
|---|---|
| `landedvessel_record` | presses *Record*: freezes the line in progress into the table and returns it (`OnRailsMm`, `SettledMm`, `MovedMm`) |
| `landedvessel_read` | reads the window: the craft it follows, the recorded lines and the line in progress |
| `landedvessel_clear` | presses *Clear table* |
| `landedvessel_move_window` | moves the window, as dragging it does: `x` and `y` in pixels from the top left corner of the screen; returns its position and size |
| `landedvessel_show_window` | shows or hides the window, as `Alt+F6` does; the reading goes on either way |

## Get it

Either way you end up with the same `GameData/KSPDiagLandedVessel/` folder.

**Download it** — from the assets of the
[latest release](https://github.com/lhervier/KSP-Diag-LandedVessel/releases/latest).

**Or compile it** — clone this repository, set `KSPDIR` to your KSP install folder and run
`build.bat`. It needs the .NET SDK and
[KSP-Util-MCPServer](https://github.com/lhervier/KSP-Util-MCPServer) installed in that KSP, takes a few seconds,
reads the KSP assemblies straight from your install, and puts the DLL in
`GameData/KSPDiagLandedVessel/` inside the repository. It does not install anything.
KSP-Util-MCPServer is only needed to compile: it provides the attribute that marks what this mod offers to
it, and this mod runs the same without it. Worth doing if you would rather not run a binary you have no source for
while reporting a measurement.

## Install

Drop `GameData/KSPDiagLandedVessel` into the `GameData` of KSP, so that you end up with
`GameData/KSPDiagLandedVessel/KSPDiagLandedVessel.dll`. It runs on a stock install.

## License

MIT
