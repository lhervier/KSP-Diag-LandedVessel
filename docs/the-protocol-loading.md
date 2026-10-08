# The protocol: loading the same save

Part of [KSP Diag - Landed Vessel](../README.md): how to take the reading on a craft that comes
back with a save, step by step. The columns it fills are in [The window](the-window.md), and what it
reads is in [The measurements: loading the same save](the-measurements-loading.md).

## The save

The protocol loads a save holding one craft landed on bare ground, on a spot where it does not slide,
and nothing else. The saves it
was played on come with this mod, in [`diag`](../diag/README.md#the-saves-of-the-loading-protocol): a
capsule on a small flat fuel tank on each of the four worlds of stock KSP, `reload-kerbin-2parts.sfs`
and the same for `mune`, `minmus` and `gilly`. Copy one into the folder of a sandbox game and load it
from that game.

To make your own, step by step: [Making the save](the-protocol-loading/making-the-save.md).

## The protocol

**1. Load the save, watch the live line until it stops moving, then press *Record* at the end of it.**

![The save just loaded, the craft settled, about to record](../imgs/protocols/reload/40-record.png)

The first line appears. **On rails** is the height the save gave back, **Settled** the height the
craft actually came to rest at, and **Moved** the difference — already not zero.

![The first loading recorded](../imgs/protocols/reload/45-recorded.png)

**2. Load the same save again, let it settle, and record again.** Not a new save: the same one, again.
A second line appears, under the first.

![A second loading recorded](../imgs/protocols/reload/50-record-again.png)

**3. Repeat step 2** until you have six lines.

![Six loadings recorded](../imgs/protocols/reload/60-record-again-and-again.png)

⚠️ **Never save during the series.** Saving each time would write a new position every time, and you
would be measuring your own round trip on top of the ground.

⚠️ **A loading where KSP moved the craft itself does not count.** At loading, KSP may run a pass that
sets a landed craft back onto the ground before its physics starts. It moves the craft only when it
finds it more than 10 cm off, and then writes a line `ground contact! - error. Moving Vessel` naming
your craft, right before `Unpacking`, in `KSP.log`. The reading then mixes that move with the ground's.

⚠️ **Do not touch the throttle.** A landed craft at rest is held in place by the game, but only while
its throttle is closed. Open it, even by a few percent, and the craft can slide: **Settled** then never
stops moving. The throttle stays where you left it: a single press of Shift is enough, and only `X`
closes it again.

Now read the table. If there were nothing wrong, it would read like this: **On rails** the same value
on every line — KSP handing the craft back exactly where it left it, loading after loading — and
**Moved** zero on every line, because the craft was set down on the ground and has nothing left to
do.

Half of that holds. **On rails** comes back to within a thousandth of a millimetre, so the save and
reload round trip is exact and the craft really is put back where it was. **Moved** is not zero on
a single line, and it is not small either.

## Played by a script

[`diag/automation/run-loading.py`](../diag/automation/run-loading.py) plays the protocol above, on
[a save already made](../diag/README.md#the-saves-of-the-loading-protocol), and takes the screenshot. It drives KSP through
[KSP-MCPServer](https://github.com/lhervier/KSP-MCPServer), a mod that answers requests sent to it over
HTTP, from the computer KSP runs on only; and it needs nothing but Python 3 — no AI, no package to
install. Anyone can read it top to bottom: it follows the steps above in the same order.

The saves it was played on are in [`diag`](../diag/README.md#the-saves-of-the-loading-protocol), made
as in [Making the save](the-protocol-loading/making-the-save.md) on each of the four worlds of stock KSP, a capsule on a small flat fuel tank:
`reload-kerbin-2parts.sfs`, and the same for `mune`, `minmus` and `gilly`. Each was checked against its rules: no `Moving Vessel` line in
`KSP.log`, and a craft that does not slide. On Real Solar System, it was played on the Moon and on Earth, on
[`reload-moon-rss-resave.sfs`](../diag/reload-moon-rss-resave.sfs) and
[`reload-earth-rss-resave.sfs`](../diag/reload-earth-rss-resave.sfs), a capsule on an empty fuel tank;
these load only on the install described in [On Real Solar System](../diag/README.md#on-real-solar-system).

1. Install KSP-MCPServer next to this mod, copy the save into a sandbox game, start KSP and wait for
   the main menu.
2. Run `python run-loading.py --folder <your sandbox game> --save reload-kerbin-2parts --loads 6 --out screenshots`.

For each loading, it loads the save, waits for the digits to stop moving (within half a thousandth of a
millimetre over two seconds), and records. If
[KSP Diag - Terrain Height](https://github.com/lhervier/KSP-Diag-TerrainHeight) is installed as well,
it records in both windows at the same moment. It never saves the game. After the last loading it takes
a screenshot of each table, prints every line it recorded, writes them to `lines.json` next to the
screenshots, and quits KSP — give it `--keep-running` to leave KSP open. Save `KSP.log` before starting
KSP again: KSP writes it anew at every start.
