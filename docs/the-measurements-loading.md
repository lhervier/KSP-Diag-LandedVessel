# The measurements: loading the same save

Part of [KSP Diag - Landed Vessel](../README.md): the readings taken with
[the loading protocol](the-protocol-loading.md), on the four worlds of stock KSP and on two much
larger ones, the Moon and Earth of Real Solar System.

## The install

KSP 1.12.5 on Windows, with `GameData` holding Harmony, ModuleManager,
[KSP Community Fixes](https://github.com/KSPModdingLibs/KSPCommunityFixes) 1.41.1, this mod,
[KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight), which reads the ground
under the same craft at the same moments, and [KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer),
which plays the protocol, and nothing else — what most players run, give or take their other mods.

The Moon and Earth are measured on an install of their own: the one above, plus
[Real Solar System](https://github.com/KSP-RO/RealSolarSystem) 20.1.3.0 and what it requires
(Kopernicus 248, Modular Flight Integrator, KSPTextureLoader, the RSS textures). Real Solar System replaces
the planets with the real ones: the Moon is more than three times the radius of Kerbin, Earth more than
ten times. It is installed as released, and it ships a workaround of its own that moves landed craft
at loading; what that does to the readings is in
[Real Solar System's own workaround](#real-solar-systems-own-workaround). The saves are in
[`diag`](../diag/README.md#on-real-solar-system); they only load there.

Every series on this page was played by
[the script of the protocol](the-protocol-loading.md#played-by-a-script), `run-loading.py`: one
session per install, every save of it loaded six times in a row, a *Record* in both instruments at each
loading, and a screenshot of the table after the sixth. The saves are in [`diag`](../diag/README.md#the-saves-of-the-loading-protocol);
the sessions, what the script printed and every line it recorded, in [`diag/runs`](../diag/README.md#the-runs-of-the-loading-protocol).

## The readings

That is the whole demonstration, and it fits in one screenshot. Here is the same save on Kerbin,
`reload-kerbin-2parts.sfs`, a capsule sitting on a small flat fuel tank on the levelled grass of the KSC,
loaded six times:

![Six loadings of the same save, on Kerbin](../imgs/measures/reload/2parts/00-kerbin.png)

The bottom line is the loading in progress, not a seventh one: after the sixth *Record*, it keeps
showing that same sixth loading, still live.

The same value in **On rails**, six times over: KSP handed the craft back in exactly the same place,
every single time. Never the same value in **Moved**: on all six, the ground turned out to be somewhere
else, here higher every time, by a different amount, and the craft was pushed back out onto it.

The craft has two parts on purpose. KSP treats a craft made of a single part apart: it puts it back
onto the ground itself at every loading (see [the protocol](the-protocol-loading.md)). With two parts,
it leaves the craft where the save put it — except on Real Solar System, below — and what the craft does
is the ground's doing alone.

The same craft, the same loadings of one save, done again on the Mun, on flat ground, on the frozen
flats of Minmus, on Gilly — the smallest place there is to stand on — and on the Moon and Earth of Real
Solar System: on flat ground on the Moon, `reload-moon-rss-resave.sfs`, and on the grass about 1.4 km
west of the KSC on Earth, `reload-earth-rss-resave.sfs`.

![Six loadings of the same save, on the Mun](../imgs/measures/reload/2parts/10-mune.png)

![Six loadings of the same save, on Minmus](../imgs/measures/reload/2parts/20-minmus.png)

![Six loadings of the same save, on Gilly](../imgs/measures/reload/2parts/30-gilly.png)

![Six loadings of the same save, on the Moon](../imgs/measures/reload/2parts/40-moon.png)

![Six loadings of the same save, on Earth](../imgs/measures/reload/2parts/50-earth.png)

| loading | Kerbin — **Moved** (mm) | Mun — **Moved** (mm) | Minmus — **Moved** (mm) | Gilly — **Moved** (mm) | the Moon — **Moved** (mm) | Earth — **Moved** (mm) |
|---|---|---|---|---|---|---|
| 1 | +30.145 | +3.527 | +4.994 | +0.014 | +66.826 | +70.856 |
| 2 | +60.502 | +6.961 | +4.428 | −0.306 | +57.434 | −165.652 *(moved down)* |
| 3 | +16.839 | −2.894 | +0.939 | +0.014 | +17.631 | −54.965 |
| 4 | +53.031 | +15.315 | −0.570 | +0.458 | +35.675 | −123.276 *(moved down)* |
| 5 | +32.949 | +11.571 | −1.751 | +2.010 | +22.327 | −80.310 |
| 6 | +27.332 | −1.118 | −2.330 | +0.037 | +60.189 | +126.724 *(moved up)* |
| **lowest to highest** | **43.7 mm** | **18.2 mm** | **7.3 mm** | **2.3 mm** | **49.2 mm** | **292.4 mm** |

*(moved up)*, *(moved down)*: the craft came back more than 10 cm inside the ground, or more than 10 cm
above it, and was moved onto it before its physics started, with a `Moving Vessel up` or
`Moving Vessel down` line in `KSP.log` giving about the same distance. The protocol asks for loadings
without such a line; on Real Solar System they cannot all be avoided, so the lines are kept, and marked.
Who moves the craft, and why, is in
[Real Solar System's own workaround](#real-solar-systems-own-workaround). On the Moon, no line was
moved: the craft came back inside the ground at all six loadings, by 18 to 67 mm, under the 10 cm the
workaround acts on, and was pushed out by the physics engine.

## Real Solar System's own workaround

**Real Solar System already moves landed craft at loading.** It ships a component,
`VesselGroundPositionEnhancer`, which runs the stock repositioning pass on every landed craft it
unpacks: a craft found more than 10 cm off the ground, inside it or above it, is moved onto it before
its physics starts, in one block, and `KSP.log` gets a `Moving Vessel` line. Under 10 cm, the pass
leaves the craft where it is, inside the ground or not. The component only acts on a *landed* craft. On
Earth, near the KSC, the craft is in the *prelaunch* situation instead, where the component does not
run; there, stock KSP runs the same pass on its own, at every loading, which is what moved the craft at
three of the six loadings above, twice down and once up. On the Moon, the component ran at all six
loadings (`[RSS-VGPE] CheckGroundCollision()` in `KSP.log`) and never had to move the craft. The
component turns itself off when an assembly named `WorldStabilizer` is loaded.

The series below were played by hand, before the ones above, watching the craft rather than the
numbers — what a script does not do.

**Six loadings of the first save of the Moon.** `reload-moon-rss.sfs`, the save the craft was first
placed with, loaded six times: **Moved** read −63.933, −5.999, +110.293, +168.523, +147.171 and
−94.096 mm, the third, fourth and fifth loadings moved up by the pass (`Moving Vessel up` lines of
about the same distance), and nothing seen to jump. Logged in `reload-moon-rss-stock.log`.

**Loading again and again.** The same save, `reload-moon-rss.sfs`, loaded again and again in another
session — fourteen loadings, all recorded:

![Fourteen loadings of the same save, on the Moon](../imgs/measures/reload/2parts/rss/30-moon-14-loads.png)

| loading | **Moved** (mm) | what the craft did |
|---|---|---|
| 1 | +257.121 | moved up by the pass (`0.257m`) |
| 2 | −45.837 | nothing |
| 3 | +417.383 | **tipped over** |
| 4 | +172.248 | moved up by the pass (`0.173m`) |
| 5 | +426.948 | **tipped over** |
| 6 | −80.558 | nothing |
| 7 | +25.460 | **jumped** |
| 8 | −12.557 | nothing |
| 9 | +226.627 | moved up by the pass (`0.227m`) |
| 10 | +260.629 | moved up by the pass (`0.261m`) |
| 11 | −4.673 | nothing |
| 12 | −10.539 | nothing |
| 13 | +223.193 | moved up by the pass (`0.223m`) |
| 14 | +114.687 | moved up by the pass (`0.115m`) |
| **lowest to highest**, the twelve loadings where the craft stayed upright | **341.2 mm** | |

Where the craft tipped over, **Moved** reads the height of a craft lying on its side, not one that
settled: those two lines are left out of the spread.

**With the component turned off**, by an empty assembly named `WorldStabilizer` in `GameData`, the first
loading of the same save was enough:

![The first loading of the same save, on the Moon, with Real Solar System's component turned off](../imgs/measures/reload/2parts/rss/20-moon-rss-pass-off.png)

**With the component on, the craft can tip over too.** At the third and fifth of the fourteen loadings
above; and twice more on the same craft saved again at a later load, `reload-moon-rss-resave.sfs`, Real
Solar System as released: at the first loading of one session, and at the fourth of six loadings
played by hand with [KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight)
installed instead of this mod. Each time, `KSP.log` shows the component running
(`[RSS-VGPE] CheckGroundCollision()`) and no `Moving Vessel` line: the craft came back less than
10 cm off the ground, and the pass left it where it was. Here is the third of the fourteen loadings,
after its *Record*:

![The third of the fourteen loadings, on the Moon, with Real Solar System as released](../imgs/measures/reload/2parts/rss/50-moon-tipped-over.png)

**The component is indispensable, and it is not enough.** Indispensable: over the twenty loadings of
`reload-moon-rss.sfs`, it moved the craft nine times, each time from 11 to 26 cm inside the ground; with
it turned off, the very first loading tipped the craft over. Not enough: it only acts beyond 10 cm,
while on the Moon the ground comes back over 26 to 34 cm from one loading to the next on that save,
which leaves plenty of room below it — of the fourteen loadings watched, one still made the craft jump
and two tipped it over, and, on the save taken again, the craft tipped over twice more. On Earth, in six
loadings of `reload-earth-rss-resave.sfs` played by hand and watched, stock's own pass let one jump
through, at the first loading (+82.712 mm), for the same reason. And where either pass does
act, it does not put the craft back where it was saved: it moves the whole of it, up or down, in one
block, onto a ground that came back somewhere else.

The sessions are logged in [`diag/runs`](../diag/README.md#on-real-solar-system): the six loadings of
`reload-moon-rss.sfs` in `reload-moon-rss-stock.log`, the fourteen in `reload-moon-rss-stock-14loads.log`,
the component turned off in `reload-moon-rss-vgpeoff-stock.log`, the first tip-over of the save taken
again in `reload-moon-rss-stock-tipped.log`, and the six loadings of Earth watched in
`reload-earth-rss-stock.log`; the six loadings played with Diag TerrainHeight on the Moon in
[Diag TerrainHeight's `diag/runs`](https://github.com/lhervier/KSP-Diag-TerrainHeight/tree/main/diag/runs),
file `reload-moon-rss-stock.log`.

**→ What they show: [What the measurements show: loading the same save](what-the-measurements-show-loading.md)**
