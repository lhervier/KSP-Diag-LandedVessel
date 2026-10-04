# The measurements: the runway and the grass beside it

Part of [KSP Diag - Landed Vessel](../README.md): the readings taken with
[the runway protocol](the-protocol-runway.md) — two identical craft, one on the grass and one on the
runway, 152 m apart, both read at each of six loadings of the same save; then the same on the Mun,
beside a runway placed by a mod. The other series are in
[The measurements: loading the same save](the-measurements-loading.md),
[The measurements: coming back to a craft you left](the-measurements-approach.md) and
[The measurements: switching to a craft far away](the-measurements-switching.md).

The save the protocol uses is [`diag/runway-kerbin.sfs`](../diag/runway-kerbin.sfs), and
[the protocol page](the-protocol-runway.md#the-save) says what it holds. The Mun series uses
[`diag/runway-mun-kk.sfs`](../diag/runway-mun-kk.sfs) and the two files beside it.

## The install

KSP 1.12.5 on Windows, with `GameData` holding Harmony, ModuleManager,
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) 1.41.1, this mod,
[KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight), which reads the ground
under the same craft at the same moments, and [KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer), which plays the
protocol, and nothing else. For the Mun, [Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs)
1.12.3 is added, with CustomPreLaunchChecks 1.8.1, which it requires.

Both series were played by [the script of the protocol](the-protocol-runway.md#played-by-a-script),
`run-runway.py`, one session each.

## The readings

Six loadings on each body, two lines each: the odd lines on the ground, the even lines on the runway,
after switching to it. The bottom line of each screenshot is the reading in progress, not a record.

**On Kerbin**, the runway of the KSC and the grass beside it:

![Six loadings on Kerbin, the craft on the grass then the craft on the runway](../imgs/measures/runway/six-loads.png)

**On rails** reads 600,065,066.673 mm on the grass at all six loadings, and 600,069,387.065 or .066 mm
on the runway. **Settled**, in millimetres, and the step between the two craft:

| loading | on the grass | on the runway | **step**: runway minus grass |
|---|---|---|---|
| 1 | 600,065,104.439 | 600,069,385.929 | 4,281.491 |
| 2 | 600,065,078.291 | 600,069,373.988 | 4,295.697 |
| 3 | 600,065,139.839 | 600,069,439.174 | 4,299.336 |
| 4 | 600,065,109.983 | 600,069,398.772 | 4,288.789 |
| 5 | 600,065,050.310 | 600,069,322.370 | 4,272.059 |
| 6 | 600,065,083.583 | 600,069,394.167 | 4,310.584 |
| **lowest to highest** | **89.5 mm** | **116.8 mm** | **38.5 mm** |

In *Moved*, the craft on the grass goes from −16.362 to +73.166 mm, the craft on the runway from −64.696
to +52.109 mm.

**On the Mun**, a runway placed by Kerbal Konstructs and the ground 42 m from it:

![Six loadings on the Mun, the craft on the ground then the craft on the runway placed by Kerbal Konstructs](../imgs/measures/runway/six-loads-mun-kk.png)

**On rails** reads 204,123,943.054 mm on the ground at all six loadings, and 204,123,079.402 to .404 mm
on the runway. **Settled**, in millimetres, and the step between the two craft:

| loading | on the ground | on the runway | **step**: runway minus ground |
|---|---|---|---|
| 1 | 204,123,862.511 | 204,123,068.484 | −794.028 |
| 2 | 204,123,880.811 | 204,123,050.799 | −830.012 |
| 3 | 204,123,885.042 | 204,123,067.278 | −817.765 |
| 4 | 204,123,871.786 | 204,123,058.734 | −813.052 |
| 5 | 204,123,888.413 | 204,123,068.358 | −820.055 |
| 6 | 204,123,883.721 | 204,123,061.701 | −822.020 |
| **lowest to highest** | **25.9 mm** | **17.7 mm** | **36.0 mm** |

In *Moved*, the craft on the ground goes from −80.543 to −54.641 mm, the craft on the runway from
−28.604 to −10.921 mm.

## What these readings show

**The game hands all four craft back at the same height every time.** *On rails* does not move by more
than two thousandths of a millimetre on any of them, on Kerbin or on the Mun.

**All four come to rest somewhere else every time.** On Kerbin, the craft on the grass settles anywhere
within 89.5 mm, as in [the loading series](the-measurements-loading.md), and the craft on the runway
within 116.8 mm. On the Mun, 25.9 mm on the ground and 17.7 mm on the runway: smaller, as the Mun is
in the loading series too. Standing on a runway deck rather than on the terrain changes nothing to that.

**The runway and the ground do not move together.** The step between the two craft is never the same
twice: it spreads over 38.5 mm on Kerbin, 36.0 mm on the Mun. On Kerbin both craft stand on flat
ground, and the step, 4.3 m, is the height of the runway deck above the grass. On the Mun the ground
slopes, and the step is not the height of the deck. Either way, it is the same two craft on the same two
spots at every loading: if the runway kept the same height relative to the ground next to it, that
step would not move.

**Whether the game or a mod places it, a structure behaves the same.** The runway of the KSC, which the
game puts in place, and a runway Kerbal Konstructs puts on another body both come back at a different
height every time, and neither keeps its height relative to the ground next to it.

As everywhere else with this instrument, what is measured is **the craft**, not what they rest on —
[what this instrument shows, and what it does not](this-mods-demonstration.md#what-this-instrument-shows-and-what-it-does-not)
applies to these readings word for word.

## The logs

[`diag/runs/runway-stock.log`](../diag/runs/runway-stock.log) — the `KSP.log` of the session the six
loadings on Kerbin were taken in; what the script printed is in
[`runway-stock-script.txt`](../diag/runs/runway-stock-script.txt), and every line it recorded, in both
instruments, in [`runway-stock-lines.json`](../diag/runs/runway-stock-lines.json).

[`diag/runs/runway-mun-kk-stock.log`](../diag/runs/runway-mun-kk-stock.log) — the `KSP.log` of the
session the six loadings on the Mun were taken in; what the script printed is in
[`runway-mun-kk-stock-script.txt`](../diag/runs/runway-mun-kk-stock-script.txt), and every line it
recorded in [`runway-mun-kk-stock-lines.json`](../diag/runs/runway-mun-kk-stock-lines.json).
