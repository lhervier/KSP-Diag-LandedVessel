# The saves and the runs

Part of [KSP Diag - Landed Vessel](../README.md): the saves and the logs of the readings taken
with [the loading protocol](../docs/the-protocol-loading.md),
[the approach protocol](../docs/the-protocol-approach.md),
[the switching protocol](../docs/the-protocol-switching.md) and
[the runway protocol](../docs/the-protocol-runway.md), and the scripts that play them. What those
readings say is in
[The measurements: loading the same save](../docs/the-measurements-loading.md),
[The measurements: coming back to a craft you left](../docs/the-measurements-approach.md),
[The measurements: switching to a craft far away](../docs/the-measurements-switching.md) and
[The measurements: the runway and the grass beside it](../docs/the-measurements-runway.md).

## The saves of the loading protocol

A lone capsule, then the same capsule on a small flat fuel tank, each landed on its own spot of the four
worlds of stock KSP, made by steps 1 to 3 of [the protocol](../docs/the-protocol-loading.md):

- [`reload-kerbin-1part.sfs`](reload-kerbin-1part.sfs) and [`reload-kerbin-2parts.sfs`](reload-kerbin-2parts.sfs)
  — on the levelled grass of the KSC, just south-west of the west end of the runway;
- [`reload-mune-1part.sfs`](reload-mune-1part.sfs) and [`reload-mune-2parts.sfs`](reload-mune-2parts.sfs)
  — on flat ground on the Mun;
- [`reload-minmus-1part.sfs`](reload-minmus-1part.sfs) and [`reload-minmus-2parts.sfs`](reload-minmus-2parts.sfs)
  — on the frozen flats of Minmus;
- [`reload-gilly-1part.sfs`](reload-gilly-1part.sfs) and [`reload-gilly-2parts.sfs`](reload-gilly-2parts.sfs)
  — on Gilly.

Copy a save into the folder of a sandbox game and load it from that game.

## The scripts

Each plays a protocol through [KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer), with Python 3
alone; how to run it is at the top of the file, and in the chapter *Played by a script* of its protocol.

- [`automation/run-loading.py`](automation/run-loading.py) — the loading protocol.
- [`automation/run-approach.py`](automation/run-approach.py) — the approach protocol.
- [`automation/run-switching.py`](automation/run-switching.py) — the switching protocol.
- [`automation/run-runway.py`](automation/run-runway.py) — the runway protocol.

## The runs of the loading protocol

KSP 1.12.5 with Harmony, ModuleManager, KSP Community Fixes 1.41.1, this mod,
KSP Diag - Terrain Height and KSP-MCPServer, every save played by `run-loading.py`, six loadings each.

- [`runs/loading-stock.log`](runs/loading-stock.log) — the `KSP.log` of the session the eight saves
  above were played in, one after the other.
- `runs/reload-<world>-<1part|2parts>-stock-script.txt` — what the script printed for each save, and
  `runs/reload-<world>-<1part|2parts>-stock-lines.json`, every line it recorded, in both instruments:
  for instance [`runs/reload-kerbin-1part-stock-lines.json`](runs/reload-kerbin-1part-stock-lines.json).
- [`runs/loading-rss-stock.log`](runs/loading-rss-stock.log) — on Real Solar System (see
  [On Real Solar System](#on-real-solar-system)): the session `reload-moon-rss-resave.sfs` then
  `reload-earth-rss-resave.sfs` were played in; what the script printed and the lines it recorded, in
  [`runs/reload-moon-rss-resave-stock-script.txt`](runs/reload-moon-rss-resave-stock-script.txt),
  [`runs/reload-moon-rss-resave-stock-lines.json`](runs/reload-moon-rss-resave-stock-lines.json),
  [`runs/reload-earth-rss-resave-stock-script.txt`](runs/reload-earth-rss-resave-stock-script.txt) and
  [`runs/reload-earth-rss-resave-stock-lines.json`](runs/reload-earth-rss-resave-stock-lines.json).

## The saves of the other protocols

- [`approach-kerbin.sfs`](approach-kerbin.sfs) — the save the approach protocol uses: a capsule
  landed on the flat grass west of the KSC, and a rover 26 m from it.
- [`switch-kerbin.sfs`](switch-kerbin.sfs) — the save the switching protocol uses: a capsule landed
  on the same grass, and a rover 1.97 km to the south of it.
- [`runway-kerbin.sfs`](runway-kerbin.sfs) — the save the runway protocol uses: two identical craft,
  one on the grass beside the runway and one on the runway, 152 m apart.
- [`runway-mun-kk.sfs`](runway-mun-kk.sfs) — the same protocol on the Mun: two identical craft, one on
  a runway placed by [Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs) 1.12.3 and one on
  the ground 42 m away. The runway itself is in the two files of
  [`runway-mun-kk/GameData/KerbalKonstructs/NewInstances/`](runway-mun-kk/GameData/KerbalKonstructs/NewInstances/):
  copy that `GameData` into the folder of KSP, over its own, before loading the save.

Copy a save into the folder of a sandbox game and load it from that game.

## The runs of the other protocols

- [`runs/switching-stock.log`](runs/switching-stock.log) — the `KSP.log` of the session the six
  switching rounds were taken in.
- [`runs/runway-stock.log`](runs/runway-stock.log) — the `KSP.log` of the session the six loadings
  of the runway protocol were taken in.
- [`runs/runway-mun-kk-stock.log`](runs/runway-mun-kk-stock.log) — the `KSP.log` of the session the six
  loadings on the Mun, beside the runway placed by Kerbal Konstructs, were taken in.
- [`runs/approach-stock-6cycles.log`](runs/approach-stock-6cycles.log) — the `KSP.log` of the session
  the six round trips were taken in, with an earlier version of the approach save: the same two
  craft, a few metres apart, 1.4 km further east.
- [`runs/approach-diag1-stock.log`](runs/approach-diag1-stock.log) — the `KSP.log` of an earlier
  session, kept for the record: its round trips stayed within range of the parked craft, so the game
  never unloaded it and there was nothing to read.

## On Real Solar System

Taken on [Real Solar System](https://github.com/KSP-RO/RealSolarSystem) 20.1.3.0 and what it requires
(Kopernicus, Modular Flight Integrator, KSPTextureLoader, the RSS textures), on an install of their own:
these saves only load there. The protocol is [the loading protocol](../docs/the-protocol-loading.md).

- [`reload-moon-rss.sfs`](reload-moon-rss.sfs) — a capsule on an empty FL-T100, landed on flat ground
  on the Moon.
- [`reload-moon-rss-resave.sfs`](reload-moon-rss-resave.sfs) — the same craft, saved again at a later
  load.
- [`reload-earth-rss-resave.sfs`](reload-earth-rss-resave.sfs) — the same kind of craft, on the grass
  about 1.4 km west of the KSC on Earth.
- [`reload-earth-rss-landed.sfs`](reload-earth-rss-landed.sfs) — the save above, with one line changed
  in the file: the situation of the craft, from `PRELAUNCH` to `LANDED`.

Copy a save into the folder of a sandbox game and load it from that game.

- [`runs/loading-rss-stock.log`](runs/loading-rss-stock.log) — six loads of `reload-moon-rss-resave.sfs`,
  then six of `reload-earth-rss-resave.sfs`, played by `run-loading.py` (see
  [The runs of the loading protocol](#the-runs-of-the-loading-protocol)).

Played by hand, before, watching the craft:

- [`runs/reload-moon-rss-stock.log`](runs/reload-moon-rss-stock.log) — six loads of
  `reload-moon-rss.sfs`, then one of a save taken after the sixth.
- [`runs/reload-moon-rss-vgpeoff-stock.log`](runs/reload-moon-rss-vgpeoff-stock.log) — the first load
  of `reload-moon-rss.sfs` with Real Solar System's `VesselGroundPositionEnhancer` turned off, by an
  empty assembly named `WorldStabilizer` in `GameData`.
- [`runs/reload-moon-rss-stock-14loads.log`](runs/reload-moon-rss-stock-14loads.log) — fourteen loads
  of `reload-moon-rss.sfs`.
- [`runs/reload-moon-rss-stock-tipped.log`](runs/reload-moon-rss-stock-tipped.log) — the first load
  of `reload-moon-rss-resave.sfs`, Real Solar System as released, where the craft tipped over, with
  KSP Diag - Terrain Height installed instead of this mod.
- [`runs/reload-earth-rss-stock.log`](runs/reload-earth-rss-stock.log) — six loads of
  `reload-earth-rss-resave.sfs`, with this mod alone.
